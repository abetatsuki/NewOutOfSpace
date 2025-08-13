using UnityEditor;
using UnityEngine;

public class PlayerCarryHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier inputNotifier;
    [SerializeField] private PlayerStatusBuffer statusBuffer;
    private bool _iscarry = false;
    private PlayerStatus currentStatus = PlayerStatus.None;


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
      if(currentStatus == PlayerStatus.Carrying)
        currentStatus = PlayerStatus.None;
      else
            currentStatus = PlayerStatus.Carrying;
      UpdateCarryStatus();
    }
    private void UpdateCarryStatus()
    {
        statusBuffer.SetStatus(currentStatus);
        if (currentStatus == PlayerStatus.Carrying)
        {
            Debug.Log("carry");

        }
        else
        {
            Debug.Log("not carry");
        }
    }
}
