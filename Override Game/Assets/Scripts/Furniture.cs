using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour, IParentObject {

    [SerializeField] private Transform topPoint;

    private classroomObject classroomObject;
    public virtual void Interact(Character character) {
    }

    public virtual void Use(Character character) {
    }

    public Transform getTopPoint() {
        return topPoint;
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
