using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(RigidbodySystem))]
public sealed class RigidbodySystem : UpdateSystem {
    Filter entities;
    public override void OnAwake() {
        entities = World.Filter.With<RigidbodyComponent>().Build();
        foreach (var entity in entities)
        {
            ref var rb = ref entity.GetComponent<RigidbodyComponent>();
            var go = entity.GetComponent<GameObjectComponent>();
            rb.rb2D = go.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    public override void OnUpdate(float deltaTime) {
    }
}