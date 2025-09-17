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

        // プレイヤーが向いている方向を基準にする
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        // Y軸方向の成分を消して「地面方向」だけ残す
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // 入力を forward/right に変換
        Vector3 moveDir = (forward * input.y + right * input.x).normalized;

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
