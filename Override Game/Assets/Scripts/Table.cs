using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour, IParentObject {

    [SerializeField] private pickUpObject pickUpObject;
    [SerializeField] private Transform topOfTable;

    private classroomObject classroomObject;
    public void Interact(Character character) {
        if (classroomObject == null) {
            //these 2 lines are not needed for our program as we do not nid to spawn things, jus used it to test pickup
            Transform classroomObjectTransform = Instantiate(pickUpObject.prefab, topOfTable);
            classroomObjectTransform.GetComponent<classroomObject>().setParentObject(this);
        } else { 
            //something on the table
            classroomObject.setParentObject(character);
        }
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
