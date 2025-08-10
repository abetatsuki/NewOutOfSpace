using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputNotifier : MonoBehaviour
{
    private PlayerInput playerInput;

    public event Action<Vector2> OnMove;
    public event Action<bool> OnSprint;
    public event Action OnCarry;
    public event Action OnCamera;

    private const string _MOVE_ACTION = "Move";
    private const string _SPRINT_ACTION = "Sprint";
    private const string _CARRY_ACTION = "Carry";
    private const string _CAMERA_ACTION = "ToggleView";

    private InputAction moveAction;
    private InputAction sprintAction;
    private InputAction carryAction;
    private InputAction cameraAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions[_MOVE_ACTION];
        sprintAction = playerInput.actions[_SPRINT_ACTION];
        carryAction = playerInput.actions[_CARRY_ACTION];
        cameraAction = playerInput.actions[_CAMERA_ACTION];
    }

    private void OnEnable()
    {
        moveAction.performed += ctx => OnMove?.Invoke(ctx.ReadValue<Vector2>());
        moveAction.canceled += ctx => OnMove?.Invoke(Vector2.zero);

        sprintAction.performed += ctx => OnSprint?.Invoke(true);
        sprintAction.canceled += ctx => OnSprint?.Invoke(false);

        carryAction.performed += ctx => OnCarry?.Invoke();
        cameraAction.performed += ctx => OnCamera?.Invoke();
    }

    private void OnDisable()
    {
        moveAction.performed -= ctx => OnMove?.Invoke(ctx.ReadValue<Vector2>());
        moveAction.canceled -= ctx => OnMove?.Invoke(Vector2.zero);

        sprintAction.performed -= ctx => OnSprint?.Invoke(true);
        sprintAction.canceled -= ctx => OnSprint?.Invoke(false);

        carryAction.performed -= ctx => OnCarry?.Invoke();
        cameraAction.performed -= ctx => OnCamera?.Invoke();
    }
}
