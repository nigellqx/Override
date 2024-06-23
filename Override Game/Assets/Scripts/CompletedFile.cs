using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedFile : MonoBehaviour {

    [Serializable]
    public struct pickUpObject_GameObject {
        public pickUpObject pickUpObject;
        public GameObject gameObject;
    }

    [SerializeField] private FileClassroomObject fileClassroomObject;
    [SerializeField] private List<pickUpObject_GameObject> pickUpObjectGameObjectList;

    private void Start() {
        fileClassroomObject.OnPaperInserted += FileClassroomObject_OnPaperInserted;

        foreach (pickUpObject_GameObject pickUpObjectGameObject in pickUpObjectGameObjectList) {
            pickUpObjectGameObject.gameObject.SetActive(false);
        }
    }

    private void FileClassroomObject_OnPaperInserted(object sender, FileClassroomObject.OnPaperInsertedEventArgs e) {
        foreach (pickUpObject_GameObject pickUpObjectGameObject in pickUpObjectGameObjectList) {
            if (pickUpObjectGameObject.pickUpObject == e.pickUpObject) {
                pickUpObjectGameObject.gameObject.SetActive(true);
            }
        }
    }
}