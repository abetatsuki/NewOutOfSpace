using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputNotifier : MonoBehaviour
{
    public event Action<Vector2> OnMove;
    public event Action OnSprintStarted;
    public event Action OnSprintCanceled;

    private InputAction moveAction;
    private InputAction sprintAction;

}
