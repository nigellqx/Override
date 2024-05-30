using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    private PlayerInputActions playerInputActions;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetNormalisedMovementVector() {
        Vector2 directionVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        directionVector = directionVector.normalized;

        Debug.Log(directionVector);
        return directionVector;
    }

}
