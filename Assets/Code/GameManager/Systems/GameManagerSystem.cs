using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(GameManagerSystem))]
public sealed class GameManagerSystem : UpdateSystem {
    GameManagerComponent gManagerComponent;
    Filter platforms;
    Filter player;
    Filter UIC;
    Filter massage;
    public override void OnAwake() {
        gManagerComponent = World.Filter.With<GameManagerComponent>().Build().First().GetComponent<GameManagerComponent>();
        player = World.Filter.With<PlayerComponent>().Build();
        platforms = World.Filter.With<PlatformsComponent>().Build();
        UIC = World.Filter.With<UIComponent>().Build();
        massage = World.Filter.With<MessageComponent>().Build();
    }

    public override void OnUpdate(float deltaTime) {
        ref var uIComponent = ref UIC.First().GetComponent<UIComponent>();
        if (gManagerComponent.isGameStart)
        {
            foreach (var item in platforms)
            {
                ref var platformsC = ref item.GetComponent<PlatformsComponent>();
                platformsC.isMoving = true;
            }
            ref var playerC = ref player.First().GetComponent<PlayerComponent>();
            ref var playerT = ref player.First().GetComponent<TransformComponent>();
            playerC.canMove = true;
            if (playerT.transform.transform.position.y < -7)
            {
                ref var messageC = ref massage.First().GetComponent<MessageComponent>();
                messageC.messageText.text = messageC.messages[Random.Range(0, messageC.messages.Length)];
                Time.timeScale = 0;
                uIComponent.LoseGameWindow.SetActive(true);
                gManagerComponent.isGameStart = false;
                ref var platformsC = ref platforms.First().GetComponent<PlatformsComponent>();
                platformsC.platformConfig.platformsSpeed = platformsC.platformConfig.platformsSpeedMin;
            }
        }
    }
}