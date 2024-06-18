using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classroomObject : MonoBehaviour {

    [SerializeField] private pickUpObject pickUpObject;

    private IParentObject parentObject;

    public pickUpObject getPickUpObject() {
        return pickUpObject;
    } 

    public void setParentObject(IParentObject parentObject) {
        if (this.parentObject != null) {
            this.parentObject.clearClassroomObject();
        }

        this.parentObject = parentObject;

        if (this.parentObject.hasClassroomObject()) {
            Debug.LogError("ParentObject already has an item");
        }

        parentObject.setClassroomObject(this);

        transform.parent = parentObject.getTopPoint();
        transform.localPosition = Vector3.zero; 
    }

    public IParentObject getParentObject() {
        return parentObject;
    }
}
