using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MobilInputSystem))]
public sealed class MobilInputSystem : UpdateSystem
{
    Filter inputComponent;
    public override void OnAwake()
    {
        inputComponent = World.Filter.With<InputComponent>().Build();
    }

    public override void OnUpdate(float deltaTime)
    {
        ref var input = ref inputComponent.First().GetComponent<InputComponent>();
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // Обработка касания
            if (touch.phase == TouchPhase.Moved)
            {
                input.Horizontal = touch.deltaPosition.normalized.x;
                Debug.Log("sdfd");
            }
        }
    }
}