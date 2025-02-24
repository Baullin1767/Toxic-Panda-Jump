using UnityEngine;

public class MobileInput : IPlayerInput
{
    private Vector2 lastTouchPosition;

    public bool IsJumpPressed()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return touch.phase == TouchPhase.Began && touch.position.y < Screen.height / 2;
        }
        return false;
    }

    public float GetHorizontalMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = (touch.position.x - lastTouchPosition.x) * 0.01f;
                lastTouchPosition = touch.position;
                return deltaX;
            }
        }
        return 0f;
    }
}
