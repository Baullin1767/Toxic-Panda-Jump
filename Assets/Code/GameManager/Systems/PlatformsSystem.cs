using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;
using Zenject;
using static UnityEngine.EventSystems.EventTrigger;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlatformsSystem))]
public sealed class PlatformsSystem : UpdateSystem {
    Filter platforms;
    Filter score;
    Filter player;
    public float screenHeight = 7f; // Высота экрана в условных единицах
    public float speedCoefficient = 0.1f; // Коэффициент k, который определяет влияние скорости

    // Функция для получения позиции появления платформы
    public float GetSpawnPosition(float speed)
    {
        float spawnPosition = Mathf.Max(9, screenHeight - speedCoefficient * speed);
        return spawnPosition;
    }
    public override void OnAwake() {
        platforms = World.Filter.With<PlatformsComponent>().Build();
        score = World.Filter.With<ScoreComponent>().Build();
        player = World.Filter.With<PlayerComponent>().Build();

        ref var platformsC = ref platforms.First().GetComponent<PlatformsComponent>();
        platformsC.platformConfig.platformsSpeed = platformsC.platformConfig.platformsSpeedMin;
    }

    public override void OnUpdate(float deltaTime)
    {
        ref var player_comp = ref player.First().GetComponent<PlayerComponent>();
        foreach (var entity in platforms)
        {
            var platformsComponent = entity.GetComponent<PlatformsComponent>();
            var transform = entity.GetComponent<TransformComponent>();
            ref var scoreC = ref score.First().GetComponent<ScoreComponent>();

            if (platformsComponent.isMoving)
            {
                transform.transform.position += Vector3.down * platformsComponent.platformConfig.platformsSpeed * Time.deltaTime;
            }
            if (transform.transform.position.y < -7f)
            {
                platformsComponent.isMoving = !platformsComponent.isFlore;
                if (!platformsComponent.isFlore)
                {
                    platformsComponent.platformConfig.platformsSpeed += 0.01f;
                    player_comp.jumpDelay = player_comp.jumpDelay > 0 ? player_comp.jumpDelay - 0.01f : 0;
                    scoreC.score++;
                    transform.transform.position = new Vector3(Random.Range(
                        platformsComponent.platformConfig.posXmin,
                        platformsComponent.platformConfig.posXmax),
                        GetSpawnPosition(platformsComponent.platformConfig.platformsSpeed));
                }
            }
        }
    }
}