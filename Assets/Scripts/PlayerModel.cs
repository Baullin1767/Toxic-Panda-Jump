using UnityEngine;

public class PlayerModel
{
    public Vector2 Position { get; private set; }
    public float JumpForce { get; } = 10f;
    public float MoveSpeed { get; } = 5f;
    private Rigidbody2D rb;
    Transform transform;

    public PlayerModel(Rigidbody2D rigidbody, Transform transform)
    {
        rb = rigidbody;
        Position = rb.position;
        this.transform = transform;
    }

    public void Jump()
    {
        rb.linearVelocity = Vector2.up * JumpForce;
    }

    public void Move(float direction)
    {
        rb.position = new(direction, transform.position.y);
    }

    public void Update()
    {
        Position = rb.position;
    }
}
