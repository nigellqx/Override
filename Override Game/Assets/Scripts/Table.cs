using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

    [SerializeField] private pickUpObject pickUpObject;
    [SerializeField] private Transform topOfTable;

    private classroomObject classroomObject;
    public void Interact() {
        Debug.Log("Interact!");
    }

    public Transform getTableTopPoint() {
        return topOfTable;
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
