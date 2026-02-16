using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    private PlayerInputActions inputActions;

    public event EventHandler Jumped;
    public event EventHandler Up;
    public event EventHandler Down;
    public event EventHandler Left;
    public event EventHandler Right;
    public event EventHandler Inverted;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        inputActions = new PlayerInputActions();

        inputActions.Player.Enable();

        inputActions.Player.Jump.performed += Jump_performed;
        inputActions.Player.Up.performed += Up_performed;
        inputActions.Player.Down.performed += Down_performed;
        inputActions.Player.Left.performed += Left_performed;
        inputActions.Player.Right.performed += Right_performed;
        inputActions.Player.Invert.performed += Invert_performed;
    }

    private void Left_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Left?.Invoke(this, EventArgs.Empty);
    }

    private void Right_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Right?.Invoke(this, EventArgs.Empty);

    }

    private void Down_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Down?.Invoke(this, EventArgs.Empty);
    }

    private void Up_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Up?.Invoke(this, EventArgs.Empty);
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Jumped?.Invoke(this, EventArgs.Empty);
    }

    private void Invert_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Inverted?.Invoke(this, EventArgs.Empty);
    }
}
