using UnityEngine;

public class PlayerSprintHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier inputNotifier;

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
        Debug.Log("スプリント処理: " + isSprinting);
        // スプリント時の速度変更など
    }
}
