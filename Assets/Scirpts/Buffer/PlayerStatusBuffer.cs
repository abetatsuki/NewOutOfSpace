using UnityEngine;
using System;

public enum MoveStatus
{
    None,
    Walking,
    Sprinting,
    Crouching,
}

public enum CarryStatus
{
    NotCarrying,
    Carrying
}

public class PlayerStatusBuffer : MonoBehaviour
{
    // 状態変更通知イベント
    public event Action<MoveStatus> OnMoveStatusChanged;
    public event Action<CarryStatus> OnCarryStatusChanged;

    public MoveStatus CurrentMoveStatus { get; private set; } = MoveStatus.None;
    public CarryStatus CurrentCarryStatus { get; private set; } = CarryStatus.NotCarrying;

    private Vector2 _moveInput = Vector2.zero;
    public Vector2 MoveInput => _moveInput;

    // 入力を受け取って MoveStatus を更新
    public void SetMoveInput(Vector2 input)
    {
        _moveInput = input;
        UpdateMoveStatusFromInput();
    }

    // MoveStatus を更新する
    public void MoveSetStatus(MoveStatus newStatus)
    {
        if (CurrentMoveStatus == newStatus) return;

        if (!CanTransition(CurrentMoveStatus, newStatus))
        {
            Debug.LogWarning($"状態遷移不可: {CurrentMoveStatus} -> {newStatus}");
            return;
        }

        CurrentMoveStatus = newStatus;
        OnMoveStatusChanged?.Invoke(CurrentMoveStatus);
    }

    // CarryStatus を更新する
    public void CarrySetStatus(CarryStatus newStatus)
    {
        if (CurrentCarryStatus == newStatus) return;

        CurrentCarryStatus = newStatus;
        OnCarryStatusChanged?.Invoke(CurrentCarryStatus);
    }

    // Carry をトグルする簡易メソッド
    public void ToggleCarry()
    {
        CarrySetStatus(CurrentCarryStatus == CarryStatus.Carrying
            ? CarryStatus.NotCarrying
            : CarryStatus.Carrying);
    }

    // 入力から自動で MoveStatus を決定
    private void UpdateMoveStatusFromInput()
    {
        if (_moveInput == Vector2.zero)
        {
            MoveSetStatus(MoveStatus.None);
        }
        else if (CurrentMoveStatus == MoveStatus.None)
        {
            MoveSetStatus(MoveStatus.Walking);
        }
        // Sprint や Crouch は外部の入力ハンドラから SetStatus される想定
    }

    // MoveStatus 遷移ルール
    private bool CanTransition(MoveStatus from, MoveStatus to)
    {
        // 例: Sprinting から Crouching は不可
        if (from == MoveStatus.Sprinting && to == MoveStatus.Crouching)
            return false;

        return true;
    }
}
