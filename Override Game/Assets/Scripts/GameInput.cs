using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour {

    public static GameInput Instance { get; private set; }

    public event EventHandler OnInteractAction;
    public event EventHandler OnUseAction;
    public event EventHandler OnPauseAction;

    public enum Binding {
        Up,
        Down,
        Left,
        Right,
        Interact,
        Use,
        Pause,
        ControllerInteract,
        ControllerUse,
        ControllerPause
    }

    private PlayerInputActions playerInputActions;

    private void Awake() {
        Instance = this;

        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.Use.performed += Use_performed;
        playerInputActions.Player.Pause.performed += Pause_performed;
    }

    private void OnDestroy() {
        playerInputActions.Player.Interact.performed -= Interact_performed;
        playerInputActions.Player.Use.performed -= Use_performed;
        playerInputActions.Player.Pause.performed -= Pause_performed;

        playerInputActions.Dispose();
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void Use_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnUseAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetNormalisedMovementVector() {
        Vector2 directionVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        directionVector = directionVector.normalized;

        return directionVector;
    }

    public string getBinding(Binding binding) {
        switch (binding) {
            default:
            case Binding.Up:
                return playerInputActions.Player.Move.bindings[1].ToDisplayString();
            case Binding.Down:
                return playerInputActions.Player.Move.bindings[2].ToDisplayString();
            case Binding.Left:
                return playerInputActions.Player.Move.bindings[3].ToDisplayString();
            case Binding.Right:
                return playerInputActions.Player.Move.bindings[4].ToDisplayString();
            case Binding.Interact:
                return playerInputActions.Player.Interact.bindings[0].ToDisplayString();
            case Binding.Use:
                return playerInputActions.Player.Use.bindings[0].ToDisplayString();
            case Binding.Pause:
                return playerInputActions.Player.Pause.bindings[0].ToDisplayString();
            case Binding.ControllerInteract:
                return playerInputActions.Player.Interact.bindings[1].ToDisplayString();
            case Binding.ControllerUse:
                return playerInputActions.Player.Use.bindings[1].ToDisplayString();
            case Binding.ControllerPause:
                return playerInputActions.Player.Pause.bindings[1].ToDisplayString();
        }
    }

    public void rebind(Binding binding, Action onActionRebound) {
        playerInputActions.Player.Disable();

        InputAction inputAction;
        int bindIndex;

        switch(binding) {
            default:
            case Binding.Up:
                inputAction = playerInputActions.Player.Move;
                bindIndex = 1;
                break;
            case Binding.Down:
                inputAction = playerInputActions.Player.Move;
                bindIndex = 2;
                break;
            case Binding.Left:
                inputAction = playerInputActions.Player.Move;
                bindIndex = 3;
                break;
            case Binding.Right:
                inputAction = playerInputActions.Player.Move;
                bindIndex = 4;
                break;
            case Binding.Interact:
                inputAction = playerInputActions.Player.Interact;
                bindIndex = 0;
                break;
            case Binding.Use:
                inputAction = playerInputActions.Player.Use;
                bindIndex = 0;
                break;
            case Binding.Pause:
                inputAction = playerInputActions.Player.Pause;
                bindIndex = 0;
                break;
            case Binding.ControllerInteract:
                inputAction = playerInputActions.Player.Interact;
                bindIndex = 1;
                break;
            case Binding.ControllerUse:
                inputAction = playerInputActions.Player.Use;
                bindIndex = 1;
                break;
            case Binding.ControllerPause:
                inputAction = playerInputActions.Player.Pause;
                bindIndex = 1;
                break;
        }

        inputAction.PerformInteractiveRebinding(bindIndex)
            .OnComplete(callback => {
                callback.Dispose();
                playerInputActions.Player.Enable();
                onActionRebound();
            })
            .Start();
    }
}
