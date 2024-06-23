using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

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

    public void removeObject() {
        parentObject.clearClassroomObject();

        Destroy(gameObject);
    }

    public static classroomObject spawnClassroomObject(pickUpObject pickUpObject, IParentObject parentObject) {
        Transform classroomObjectTransform = Instantiate(pickUpObject.prefab);
        classroomObject classroomObject = classroomObjectTransform.GetComponent<classroomObject>();
        classroomObject.setParentObject(parentObject);
        return classroomObject;
    }
    
    public bool TryGetFile(out FileClassroomObject fileClassroomObject) {
        if (this is FileClassroomObject) {
            fileClassroomObject = this as FileClassroomObject;
            return true;
        } else {
            fileClassroomObject = null;
            return false;
        }
    }
}
