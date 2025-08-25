using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputNotifier : MonoBehaviour
{
    private PlayerInput playerInput;

    public event Action<Vector2> OnMove;
    public event Action<bool> OnSprint;
    public event Action  OnCarry;
    public event Action OnCamera;
    public event Action OnAttack;
    public event Action OnThrow;
   

    private const string MOVE_ACTION = "Move";
    private const string SPRINT_ACTION = "Sprint";
    private const string CARRY_ACTION = "Carry";
    private const string CAMERA_ACTION = "ToggleView";
    private const string ATTACK_ACTION = "Attack";
    private const string THROW_ACTION = "Throw";

    private InputAction _moveAction;
    private InputAction _sprintAction;
    private InputAction _carryAction;
    private InputAction _cameraAction;
    private InputAction _attackAction;
    private InputAction _throwAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        _moveAction = playerInput.actions[MOVE_ACTION];
        _sprintAction = playerInput.actions[SPRINT_ACTION];
        _carryAction = playerInput.actions[CARRY_ACTION];
        _cameraAction = playerInput.actions[CAMERA_ACTION];
        _attackAction = playerInput.actions[ATTACK_ACTION];
        _throwAction = playerInput.actions[THROW_ACTION];
    }

    private void OnEnable()
    {
        _moveAction.performed += ctx => OnMove?.Invoke(ctx.ReadValue<Vector2>());
        _moveAction.canceled += ctx => OnMove?.Invoke(Vector2.zero);

        _sprintAction.performed += ctx => OnSprint?.Invoke(true);
        _sprintAction.canceled += ctx => OnSprint?.Invoke(false);

        _carryAction.performed += ctx => OnCarry?.Invoke();
        
        _cameraAction.performed += ctx => OnCamera?.Invoke();

        _attackAction.performed += ctx => OnAttack?.Invoke();
        _throwAction.performed += ctx => OnThrow?.Invoke();
    }

    private void OnDisable()
    {
        _moveAction.performed -= ctx => OnMove?.Invoke(ctx.ReadValue<Vector2>());
        _moveAction.canceled -= ctx => OnMove?.Invoke(Vector2.zero);

        _sprintAction.performed -= ctx => OnSprint?.Invoke(true);
        _sprintAction.canceled -= ctx => OnSprint?.Invoke(false);

        _carryAction.performed -= ctx => OnCarry?.Invoke();
       
        _cameraAction.performed -= ctx => OnCamera?.Invoke();

        _attackAction.performed-= ctx => OnAttack?.Invoke();
        _throwAction.performed -= ctx => OnThrow?.Invoke();
    }
}
