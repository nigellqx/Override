using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classroomObject : MonoBehaviour {

    [SerializeField] private pickUpObject pickUpObject;

    public pickUpObject getPickUpObject() {
        return pickUpObject;
    } 
}
