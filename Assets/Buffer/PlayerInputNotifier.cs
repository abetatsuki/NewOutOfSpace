using UnityEngine;
using UnityEngine.InputSystem;
using System;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputNotifier : MonoBehaviour
{
    private const string MOVE_ACTION = "Move";
    private const string SPRINT_ACTION = "Sprint";
    private const string CARRY_ACTION = "Carry";

    public event Action<Vector2> OnMove;   // 移動入力時通知
    public event Action<bool> OnSprint;    // スプリント状態通知
    public event Action OnCarry;           // キャリー入力通知

    private InputAction moveAction;
    private InputAction sprintAction;
    private InputAction carryAction;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions[MOVE_ACTION];
        sprintAction = playerInput.actions[SPRINT_ACTION];
        carryAction = playerInput.actions[CARRY_ACTION];
    }

    private void OnEnable()
    {
        // MOVEアクション
        moveAction.performed += ctx => OnMove?.Invoke(ctx.ReadValue<Vector2>()); //ラムダ式は引数=>関数のこと　+=ctxは計算結果を返している
        moveAction.canceled += ctx => OnMove?.Invoke(Vector2.zero);

        // SPRINTアクション
        sprintAction.performed += ctx => OnSprint?.Invoke(true);
        sprintAction.canceled += ctx => OnSprint?.Invoke(false);

        // CARRYアクション
        carryAction.performed += ctx => OnCarry?.Invoke();
    }

    private void OnDisable()
    {
        moveAction.performed -= ctx => OnMove?.Invoke(ctx.ReadValue<Vector2>());
        moveAction.canceled -= ctx => OnMove?.Invoke(Vector2.zero);

        sprintAction.performed -= ctx => OnSprint?.Invoke(true);
        sprintAction.canceled -= ctx => OnSprint?.Invoke(false);

        carryAction.performed -= ctx => OnCarry?.Invoke();
    }
}
