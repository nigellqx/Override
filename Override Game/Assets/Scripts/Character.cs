using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 8.0f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    // Update is called once per frame
    void Update()
    {
        Vector2 directionVector = gameInput.GetNormalisedMovementVector();
        Vector3 newPosition = new Vector3(directionVector.x, 0f, directionVector.y);
        transform.position += newPosition * Time.deltaTime * moveSpeed;
        transform.forward = Vector3.Slerp(transform.forward, newPosition, Time.deltaTime * rotateSpeed);
        isWalking = newPosition != Vector3.zero; 
    }

    public bool IsWalking() {
        return isWalking;
    }
}
