using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

    [SerializeField] private pickUpObject pickUpObject;
    [SerializeField] private Transform topOfTable;
    public void Interact() {
        Debug.Log("Interact!");
    }
}
