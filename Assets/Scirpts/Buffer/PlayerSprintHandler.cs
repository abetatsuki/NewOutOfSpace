// スプリント状態管理クラス。スプリント入力を受けて状態を変更する
using UnityEngine;

public class PlayerSprintHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier _inputNotifier;
    [SerializeField] private PlayerStatusBuffer _statusBuffer;

    private void OnEnable()
    {
        _inputNotifier.OnSprint += HandleSprint;
    }

    private void OnDisable()
    {
        _inputNotifier.OnSprint -= HandleSprint;
    }

    private void HandleSprint(bool isSprinting)
    {
        if (isSprinting)
        {
            _statusBuffer.MoveSetStatus(MoveStatus.Sprinting);
        }
        else
        {
            // スプリント解除時は歩行に戻すなど状況に応じて調整
            _statusBuffer.MoveSetStatus(MoveStatus.Walking);
        }
    }
}
