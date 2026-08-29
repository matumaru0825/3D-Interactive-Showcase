using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // WASDの入力
        Vector2 input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
        {
            input.y += 1;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            input.y -= 1;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            input.x -= 1;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            input.x += 1;
        }

        // 移動方向
        Vector3 movement = new Vector3(input.x, 0f, input.y);

        // 移動
        rb.MovePosition(
            rb.position + movement * moveSpeed * Time.deltaTime
        );

        // ジャンプ
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddForce(
                Vector3.up * jumpForce,
                ForceMode.Impulse
            );
        }
    }
}