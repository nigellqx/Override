using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Character : MonoBehaviour, IParentObject {
    // Start is called before the first frame update

    public static Character Instance { get; private set; }

    public event EventHandler<SelectedTableChangingArgs> SelectedTableChanging;
    public class SelectedTableChangingArgs : EventArgs {
        public Furniture selectedFurniture;
    }
    
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 8.0f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform holdingPoint;

    private bool isWalking;
    private Vector3 facingDirection;
    private Furniture selectedFurniture;
    private classroomObject classroomObject;


    private void Awake() {
        if (Instance != null) {
            Debug.LogError("Too many player instances");
        }
        Instance = this;
    }

    private void Start() {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnUseAction += GameInput_OnUseAction;
    }

    private void GameInput_OnUseAction(object sender, EventArgs e) {
        if (!OverrideGameManager.Instance.isGamePlaying()) return;
        if (OverrideGameManager.Instance.isGamePaused()) return;

        if (selectedFurniture != null) {
            selectedFurniture.Use(this);
        }
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e) {
        if (!OverrideGameManager.Instance.isGamePlaying()) return;
        if (OverrideGameManager.Instance.isGamePaused()) return;

        if (selectedFurniture != null) {
            selectedFurniture.Interact(this);
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
            if (raycastHit.transform.TryGetComponent(out Furniture furniture)) {
                //Sees Table
                if (furniture != selectedFurniture) {
                    SetSelectedTable(furniture);
                }
            } else {
                SetSelectedTable(null);
            }
        } else {
            SetSelectedTable(null);
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
            willCollide = newPosition.x == 0 || Physics.CapsuleCast(transform.position, transform.position + Vector3.up * characterHeight, characterRadius, newPositionX, distanceMoved);

            //Can move in X-direction
            if (!willCollide) {
                newPosition = newPositionX;
            } else {

                //Cannot move in X-direction, try moving in Z-direction
                Vector3 newPositionZ = new Vector3(0, 0, newPosition.z);
                willCollide = newPosition.z == 0 || Physics.CapsuleCast(transform.position, transform.position + Vector3.up * characterHeight, characterRadius, newPositionZ, distanceMoved);

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

    private void SetSelectedTable(Furniture furniture) {
        selectedFurniture = furniture;

        SelectedTableChanging?.Invoke(this, new SelectedTableChangingArgs {
            selectedFurniture = furniture
        });
    }

    public Transform getTopPoint() {
        return holdingPoint;
    }

    public void setClassroomObject(classroomObject classroomObject) {
        this.classroomObject = classroomObject;
    }

    public classroomObject GetClassroomObject() {
        return classroomObject;
    }

    public void clearClassroomObject() {
        this.classroomObject = null;
    }

    public bool hasClassroomObject() {
        return this.classroomObject != null;
    }
}
