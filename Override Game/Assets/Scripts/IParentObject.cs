using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IParentObject {
    public Transform getTopPoint();

    public void setClassroomObject(classroomObject classroomObject);

    public classroomObject GetClassroomObject();

    public void clearClassroomObject();

    public bool hasClassroomObject(); 
}
