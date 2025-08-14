using UnityEngine;

public class PlayerCarryHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier inputNotifier;
    [SerializeField] private PlayerStatusBuffer statusBuffer;

    private void OnEnable()
    {
        inputNotifier.OnCarry += HandleCarry;
    }

    private void OnDisable()
    {
        inputNotifier.OnCarry -= HandleCarry;
    }

    private void HandleCarry()
    {
        // statusBuffer 側のトグルを呼ぶだけ
        statusBuffer.ToggleCarry();

        // デバッグログ
        if (statusBuffer.CurrentCarryStatus == CarryStatus.Carrying)
            Debug.Log("carry");
        else
            Debug.Log("not carry");
    }


}
