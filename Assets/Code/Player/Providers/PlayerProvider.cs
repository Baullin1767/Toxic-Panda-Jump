using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[RequireComponent(typeof(InputProvider))]
[RequireComponent(typeof(GameobjectProvider))]
[RequireComponent(typeof(RigidbodyProvider))]
[RequireComponent(typeof(TransformProvider))]
public sealed class PlayerProvider : MonoProvider<PlayerComponent> {
}