using Scellecs.Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[System.Serializable]
[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public struct PlayerComponent : IComponent {
    public bool canMove;

    public float speed;
    public float forceJump;
    public float jumpDelay;
    public float curJumpDelay;

    public bool onGround;
    public float rangeOnGround;
    public Transform onGroundCentre;
    public LayerMask layerMaskOnGround;

    public SpriteRenderer sprite;
    public Sprite idleSprite;
    public Sprite jumpSprite;
}