using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;
using UnityEngine.SceneManagement;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ButtonResponseSystem ))]
public sealed class ButtonResponseSystem  : UpdateSystem
{
    Filter UIC;
    Filter gManager;

    public override void OnAwake()
    {
        UIEventDispatcher.Instance.OnButtonStartPress += StartGame;
        UIC = World.Filter.With<UIComponent>().Build();
        gManager = World.Filter.With<GameManagerComponent>().Build();
    }

    private void StartGame()
    {
        var gManagerComponent = gManager.First().GetComponent<GameManagerComponent>();
        ref var uIComponent = ref UIC.First().GetComponent<UIComponent>();
        gManagerComponent.isGameStart = true;
        uIComponent.StartGameWindow.SetActive(false);
        Time.timeScale = 1;
    }

    public override void OnUpdate(float deltaTime)
    {
        // Обновление системы, если это необходимо
    }

    public override void Dispose()
    {
        UIEventDispatcher.Instance.OnButtonStartPress -= StartGame;
    }
}