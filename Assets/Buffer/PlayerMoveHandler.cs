// 具体的な移動処理を担当。バッファーの状態を参照する
using UnityEngine;

public class PlayerMoveHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier _inputNotifier;
    [SerializeField] private PlayerStatusBuffer _statusBuffer;
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float _baseSpeed = 5f;
    [SerializeField] private float _sprintBonusSpeed = 3f;

    private void OnEnable()
    {
        _inputNotifier.OnMove += _statusBuffer.SetMoveInput;
    }

    private void OnDisable()
    {
        _inputNotifier.OnMove -= _statusBuffer.SetMoveInput;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        Vector2 input = _statusBuffer.MoveInput;
        Vector3 moveDir = new Vector3(input.x, 0, input.y);

        float speed = GetSpeedByStatus();

        Vector3 velocity = moveDir * speed;
        _rb.linearVelocity = new Vector3(velocity.x, _rb.linearVelocity.y, velocity.z);
    }
    private float GetSpeedByStatus()
    {
        switch (_statusBuffer.CurrentMoveStatus)
        {
            case MoveStatus.None:
                return 0f;

            case MoveStatus.Walking:
                return _baseSpeed;

            case MoveStatus.Sprinting:
                return _baseSpeed + _sprintBonusSpeed;

            default:
                return _baseSpeed;
        }
    }
}
