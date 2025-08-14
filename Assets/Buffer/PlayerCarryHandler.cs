using UnityEngine;

public class PlayerCarryHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier _inputNotifier;
    [SerializeField] private PlayerStatusBuffer _statusBuffer;
    [SerializeField] private RayCastController _rayCastController;

    private void OnEnable()
    {
        _inputNotifier.OnCarry += HandleCarry;
    }

    private void OnDisable()
    {
        _inputNotifier.OnCarry -= HandleCarry;
    }

    private void HandleCarry()
    {
        // statusBuffer 側のトグルを呼ぶだけ
        _statusBuffer.ToggleCarry();

        // デバッグログ
        if (_statusBuffer.CurrentCarryStatus == CarryStatus.Carrying)//ステータスを持っている状態で変更できるようにしろ
            _rayCastController.raycastCon();
        else
            Debug.Log("not carry");
    }


}
