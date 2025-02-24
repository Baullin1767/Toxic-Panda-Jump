using UnityEngine;

public class KeyboardInput : IPlayerInput
{
    public bool IsJumpPressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public float GetHorizontalMovement()
    {
        return Input.GetAxis("Horizontal");
    }
}
