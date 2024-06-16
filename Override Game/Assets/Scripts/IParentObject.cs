using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IParentObject {
    public Transform getTableTopPoint();

    public void setClassroomObject(classroomObject classroomObject);

    public classroomObject GetClassroomObject();

    public void clearClassroomObject();

    public bool hasClassroomObject(); 
}
