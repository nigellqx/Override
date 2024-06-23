using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileClassroomObject : classroomObject {

    public event EventHandler<OnPaperInsertedEventArgs> OnPaperInserted;

    public class OnPaperInsertedEventArgs : EventArgs {
        public pickUpObject pickUpObject;
    }

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

            OnPaperInserted?.Invoke(this, new OnPaperInsertedEventArgs {
                pickUpObject = pickUpObject
            });

            return true;
        }
    }
}
