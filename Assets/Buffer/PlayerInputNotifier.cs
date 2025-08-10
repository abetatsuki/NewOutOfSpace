// 入力を受け取ってバッファに渡す役割
using System;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputNotifier : MonoBehaviour
{
    private PlayerInput playerInput;

    public event Action<Vector2> OnMove;
    public event Action<bool> OnSprint;
    public event Action OnCarry;

    private InputAction moveAction;
    private InputAction sprintAction;
    private InputAction carryAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        sprintAction = playerInput.actions["Sprint"];
        carryAction = playerInput.actions["Carry"];
    }

    private void OnEnable()
    {
        moveAction.performed += ctx => OnMove?.Invoke(ctx.ReadValue<Vector2>());
        moveAction.canceled += ctx => OnMove?.Invoke(Vector2.zero);

        sprintAction.performed += ctx => OnSprint?.Invoke(true);
        sprintAction.canceled += ctx => OnSprint?.Invoke(false);

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
