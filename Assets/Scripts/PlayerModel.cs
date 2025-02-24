using UnityEngine;

public class PlayerModel
{
    public Vector2 Position { get; private set; }
    public float JumpForce { get; } = 10f;
    public float MoveSpeed { get; } = 5f;
    private Rigidbody2D rb;

    public PlayerModel(Rigidbody2D rigidbody)
    {
        rb = rigidbody;
        Position = rb.position;
    }

    public void Jump()
    {
        rb.linearVelocity = Vector2.up * JumpForce;
    }

    public void Move(float direction)
    {
        rb.linearVelocity = new Vector2(direction * MoveSpeed, rb.linearVelocity.y);
    }

    public void Update()
    {
        Position = rb.position;
    }
}
