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
        Vector2 input = statusBuffer.MoveInput;
        Vector3 moveDir = new Vector3(input.x, 0f, input.y);

        float speed = baseSpeed;
        if (statusBuffer.CurrentStatus == PlayerStatus.Sprinting)
        {
            speed += sprintBonusSpeed;
        }

        Vector3 velocity = moveDir * speed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
    }
}
