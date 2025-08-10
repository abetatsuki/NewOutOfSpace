using UnityEngine;

public class PlayerSprintHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier inputNotifier;

    // 外部からスプリント状態を参照できるようにプロパティ化
    public bool IsSprinting { get; private set; }

    // スプリント状態が変わったことを通知するイベント（必要なら）
    public event System.Action<bool> OnSprintChanged;

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
        if (IsSprinting == isSprinting) return; // 変化がなければ処理しない

        IsSprinting = isSprinting;
        OnSprintChanged?.Invoke(isSprinting);

        
    }
}
