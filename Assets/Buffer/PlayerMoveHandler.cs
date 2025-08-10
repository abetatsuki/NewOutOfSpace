using UnityEngine;

public class PlayerMoveHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier inputNotifier;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;

    private Vector3 moveDirection;
    private void OnEnable()
    {
        inputNotifier.OnMove += HandleMove;
    }

    private void OnDisable()
    {
        inputNotifier.OnMove -= HandleMove;
    }

    private void HandleMove(Vector2 input)
    {
         moveDirection = new Vector3(input.x, 0f, input.y);  // YはZにマッピング
                                                                    // ここでmoveDirectionを使う（XZ平面移動）
    }


    private void FixedUpdate()
    {
        Vector3 velocity = moveDirection * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z); // Y軸の速度は維持
    }
}
