using UnityEngine;

public class KeyboardInput : IPlayerInput
{
    public bool IsJumpPressed()
    {
        return Input.GetMouseButtonDown(0);
    }

    public float? GetHorizontalMovement()
    {
        if (Input.GetMouseButton(0))
            return Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        else
            return null;
    }
}
