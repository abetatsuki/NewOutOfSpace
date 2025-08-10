using UnityEngine;

public class PlayerStatusBuffer : MonoBehaviour
{
    public PlayerStatus CurrentStatus { get; private set; } = PlayerStatus.None;

    private Vector2 moveInput = Vector2.zero;

    public Vector2 MoveInput => moveInput;

    public void SetMoveInput(Vector2 input)
    {
        moveInput = input;
        UpdateStatus();
    }

    public void SetSprintStatus(PlayerStatus status)
    {
        CurrentStatus = status;
    }

    private void UpdateStatus()
    {
        // ここではMove入力でNone→何かの判定はしないが、必要に応じて拡張可能
    }
}
