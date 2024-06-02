using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 8.0f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;
    private Vector3 facingDirection;

    private void Start() {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e) {
        Vector2 directionVector = gameInput.GetNormalisedMovementVector();
        Vector3 newPosition = new Vector3(directionVector.x, 0f, directionVector.y);

        //save direction that player currently faces
        if (newPosition != Vector3.zero) {
            facingDirection = newPosition;
        }

        float interactDistance = 1f;
        if (Physics.Raycast(transform.position, facingDirection, out RaycastHit raycastHit, interactDistance)) {
            if (raycastHit.transform.TryGetComponent(out Table table)) {
                //Sees Table
                table.Interact();
            }
        }

    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
        Interactions();
    }

    public bool IsWalking() {
        return isWalking;
    }

    private void Interactions() {
        Vector2 directionVector = gameInput.GetNormalisedMovementVector();
        Vector3 newPosition = new Vector3(directionVector.x, 0f, directionVector.y);

        //save direction that player currently faces
        if (newPosition != Vector3.zero) {
            facingDirection = newPosition;
        }

        float interactDistance = 1f;        
        if (Physics.Raycast(transform.position, facingDirection, out RaycastHit raycastHit, interactDistance)) {
            if (raycastHit.transform.TryGetComponent(out Table table)) {
                //Sees Table
                //table.Interact();
            }          
        }
        
    }

    private void Movement() {
        Vector2 directionVector = gameInput.GetNormalisedMovementVector();
        Vector3 newPosition = new Vector3(directionVector.x, 0f, directionVector.y);

        float characterRadius = 0.3f;
        float characterHeight = 5.0f;
        float distanceMoved = Time.deltaTime * moveSpeed;


        bool willCollide = Physics.CapsuleCast(transform.position, transform.position + Vector3.up * characterHeight, characterRadius, newPosition, distanceMoved);

        //For diagonal movements
        if (willCollide) {

            //Try moving in X-direction
            Vector3 newPositionX = new Vector3(newPosition.x, 0, 0);
            willCollide = Physics.CapsuleCast(transform.position, transform.position + Vector3.up * characterHeight, characterRadius, newPositionX, distanceMoved);

            //Can move in X-direction
            if (!willCollide) {
                newPosition = newPositionX;
            } else {

                //Cannot move in X-direction, try moving in Z-direction
                Vector3 newPositionZ = new Vector3(0, 0, newPosition.z);
                willCollide = Physics.CapsuleCast(transform.position, transform.position + Vector3.up * characterHeight, characterRadius, newPositionZ, distanceMoved);

                //Can move in Z-direction
                if (!willCollide) {
                    newPosition = newPositionZ;
                } else {
                    //Do nothing
                }
            }
        }

        if (!willCollide) {
            transform.position += newPosition * distanceMoved;
        }

        transform.forward = Vector3.Slerp(transform.forward, newPosition, Time.deltaTime * rotateSpeed);
        isWalking = newPosition != Vector3.zero;
    }

}
