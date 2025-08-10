using UnityEngine;
using System;

public class PlayerSprintHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier inputNotifier;
    [SerializeField] private PlayerStatusBuffer statusBuffer;

    public event Action<PlayerStatus> OnSprintStatusChanged;

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
        var newStatus = isSprinting ? PlayerStatus.Sprinting : PlayerStatus.None;

        if (statusBuffer.CurrentStatus == newStatus) return;

        statusBuffer.SetSprintStatus(newStatus);
        OnSprintStatusChanged?.Invoke(newStatus);
    }
}
