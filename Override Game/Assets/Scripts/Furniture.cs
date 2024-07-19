using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour, IParentObject {

    public static event EventHandler OnDrop;

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

        if (classroomObject != null) {
            OnDrop?.Invoke(this, EventArgs.Empty);
        }
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
