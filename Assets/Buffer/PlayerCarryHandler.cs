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

    private void HandleCarry(bool IsCarry )
    {
        if (IsCarry)
        {
            statusBuffer.SetStatus(PlayerStatus.Carrying);
        }
        else
        {
            statusBuffer.SetStatus(PlayerStatus.None);
        }
    }
}
