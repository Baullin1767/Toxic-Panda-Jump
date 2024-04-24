using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(InputSystem))]
public sealed class InputSystem : UpdateSystem {
    Filter inputComponent;
    public override void OnAwake()
    {
        inputComponent = World.Filter.With<InputComponent>().Build();
    }
    public override void OnUpdate(float deltaTime) {
        ref var input = ref inputComponent.First().GetComponent<InputComponent>();
        input.Horizontal = Input.GetAxis("Horizontal");
    }
}