using UnityEngine;

public interface IPlayerInput
{
    bool IsJumpPressed();
    float? GetHorizontalMovement();
}
