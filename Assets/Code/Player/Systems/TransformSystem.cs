using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(TransformSystem))]
public sealed class TransformSystem : UpdateSystem {
    Filter entities;
    public override void OnAwake()
    {
        entities = World.Filter.With<TransformComponent>().Build();
        foreach (var entity in entities)
        {
            ref var transform = ref entity.GetComponent<TransformComponent>();
            var go = entity.GetComponent<GameObjectComponent>();
            transform.transform = go.gameObject.transform;
        }
    }
    public override void OnUpdate(float deltaTime) {
    }
}