// スプリント状態管理クラス。スプリント入力を受けて状態を変更する
using UnityEngine;

public class PlayerSprintHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier inputNotifier;
    [SerializeField] private PlayerStatusBuffer statusBuffer;

    private void OnEnable()
    {
        inputNotifier.OnSprint += HandleSprint;
    }

    private void OnDisable()
    {
        inputNotifier.OnSprint -= HandleSprint;
    }

    private void HandleSprint(bool isSprinting)
    {
        if (isSprinting)
        {
            statusBuffer.SetStatus(PlayerStatus.Sprinting);
        }
        else
        {
            // スプリント解除時は歩行に戻すなど状況に応じて調整
            statusBuffer.SetStatus(PlayerStatus.Walking);
        }
    }
}
