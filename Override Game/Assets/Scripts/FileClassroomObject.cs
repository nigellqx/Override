using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileClassroomObject : classroomObject {

    [SerializeField] private List<pickUpObject> paperList;

    private List<pickUpObject> pickUpObjectList;

    private void Awake() {
        pickUpObjectList = new List<pickUpObject>();
    }
    public bool TryInsertPaper(pickUpObject pickUpObject) {
        if (!paperList.Contains(pickUpObject)) {
            return false;
        } 
        if (pickUpObjectList.Contains(pickUpObject)) {
            return false;
        } else {
            pickUpObjectList.Add(pickUpObject);
            return true;
        }
    }
}
