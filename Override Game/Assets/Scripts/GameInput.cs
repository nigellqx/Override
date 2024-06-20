using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnUseAction;

    private PlayerInputActions playerInputActions;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.Use.performed += Use_performed;
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

}
