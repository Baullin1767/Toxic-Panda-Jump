using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerModel model;
    private IPlayerInput playerInput;

    void Start()
    {
        model = new PlayerModel(GetComponent<Rigidbody2D>());

#if UNITY_ANDROID || UNITY_IOS
        playerInput = new MobileInput();
#else
            playerInput = new KeyboardInput();
#endif
    }

    void Update()
    {
        if (playerInput.IsJumpPressed())
        {
            model.Jump();
        }

        float move = playerInput.GetHorizontalMovement();
        model.Move(move);

        model.Update();
    }
}
