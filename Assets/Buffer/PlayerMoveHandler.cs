// 具体的な移動処理を担当。バッファーの状態を参照する
using UnityEngine;

public class PlayerMoveHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier inputNotifier;
    [SerializeField] private PlayerStatusBuffer statusBuffer;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float sprintBonusSpeed = 3f;

    private void OnEnable()
    {
        inputNotifier.OnMove += statusBuffer.SetMoveInput;
    }

    private void OnDisable()
    {
        inputNotifier.OnMove -= statusBuffer.SetMoveInput;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        Vector2 input = statusBuffer.MoveInput;
        Vector3 moveDir = new Vector3(input.x, 0, input.y);

        float speed = GetSpeedByStatus();

        Vector3 velocity = moveDir * speed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
    }
    private float GetSpeedByStatus()
    {
        switch (statusBuffer.CurrentMoveStatus)
        {
            case MoveStatus.None:
                return 0f;

            case MoveStatus.Walking:
                return baseSpeed;

            case MoveStatus.Sprinting:
                return baseSpeed + sprintBonusSpeed;

            default:
                return baseSpeed;
        }
    }
}
