using UnityEngine;
using System;

public enum PlayerStatus
{
    None,
    Walking,
    Carrying,
    Sprinting,
    Crouching,

    // 必要に応じて増やす
}

public class PlayerStatusBuffer : MonoBehaviour
{
    // 状態変更通知イベント（必要なら）
    public event Action<PlayerStatus> OnStatusChanged;

    public PlayerStatus CurrentStatus { get; private set; } = PlayerStatus.None;
   

    private Vector2 moveInput = Vector2.zero;
    public Vector2 MoveInput => moveInput;

    public void SetMoveInput(Vector2 input)
    {
        moveInput = input;
        UpdateStatusFromInput();
    }

  

    // 状態変更は必ずこのメソッドを通す
    public void SetStatus(PlayerStatus newStatus)
    {
        if (CurrentStatus == newStatus) return;

        // 状態遷移ルールをここで管理
        if (!CanTransition(CurrentStatus, newStatus))
        {
            Debug.LogWarning($"状態遷移不可: {CurrentStatus} -> {newStatus}");
            return;
        }

        CurrentStatus = newStatus;
        OnStatusChanged?.Invoke(CurrentStatus);
    }

    private void UpdateStatusFromInput()
    {
        // 入力による自動状態遷移例（必要なら）
        if (moveInput == Vector2.zero)
        {
            SetStatus(PlayerStatus.None);
        }
        else if (CurrentStatus == PlayerStatus.None)
        {
            SetStatus(PlayerStatus.Walking);
        }
        // スプリントやしゃがみは外部の入力ハンドラからSetStatusされる想定
    }

    // 状態遷移可能か判定（必要に応じて拡張）
    private bool CanTransition(PlayerStatus from, PlayerStatus to)
    {
        // 例: SprintingからCrouchingは不可
        if (from == PlayerStatus.Sprinting && to == PlayerStatus.Crouching)
            return false;

        // その他のルールを追加可能

        return true; // 特に制限なし
    }
}
