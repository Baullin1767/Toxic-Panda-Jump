using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float baseSpeed = 2f;
    private float speedMultiplier = 0.1f;

    void Update()
    {
        transform.position += Vector3.down * baseSpeed * Time.deltaTime;

        baseSpeed += speedMultiplier * Time.deltaTime;

        if (transform.position.y < -6f)
        {
            ResetPlatform();
        }
    }

    void ResetPlatform()
    {
        float newX = Random.Range(-2f, 2f);
        float newY = transform.position.y + 10f;
        transform.position = new Vector3(newX, newY, 0);
    }
}
