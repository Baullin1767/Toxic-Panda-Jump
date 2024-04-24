using Scellecs.Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Zenject;

[System.Serializable]
[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public struct PlatformsComponent : IComponent {
    public float speed;
    public bool isFlore;
    public bool isMoving;
    [Inject]
    public PlatformConfig platformConfig;
}