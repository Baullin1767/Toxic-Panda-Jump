using UnityEngine;

public class PandaTouchControl : MonoBehaviour
{
    public float jumpForce = 10f; // ???? ??????
    public float moveSpeedMultiplier = 0.01f; // ??????????? ???????? ????????
    private Rigidbody2D rb;
    private Vector2 lastTouchPosition;
    private bool isTouching = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // ?????? ???????
            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position;

                // ???????, ???? ??????? ? ?????? ????? ??????
                if (touch.position.y < Screen.height / 2)
                {
                    Jump();
                }
                else
                {
                    isTouching = true;
                }
            }

            // ???? ????? ????????, ????????? ??????????
            if (touch.phase == TouchPhase.Moved && isTouching)
            {
                Vector2 touchDelta = touch.position - lastTouchPosition;
                transform.position += new Vector3(touchDelta.x * moveSpeedMultiplier, 0, 0);
                lastTouchPosition = touch.position;
            }

            // ????? ???????
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouching = false;
            }
        }
    }

    void Jump()
    {
        rb.linearVelocity = Vector2.up * jumpForce;
    }
}
