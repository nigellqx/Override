using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CompletedFile;

public class PaperIconUI : MonoBehaviour {

    [SerializeField] private FileClassroomObject fileClassroomObject;
    [SerializeField] private Transform iconTemplate;

    private void Awake() {
        iconTemplate.gameObject.SetActive(false);  
    }

    private void Start() {
        fileClassroomObject.OnPaperInserted += FileClassroomObject_OnPaperInserted;
    }

    private void FileClassroomObject_OnPaperInserted(object sender, FileClassroomObject.OnPaperInsertedEventArgs e) {
        UpdateIcons();
    }

    private void UpdateIcons() {
        foreach(Transform icon in transform) {
            if (icon == iconTemplate) continue;
            Destroy(icon.gameObject);
        }

        foreach(pickUpObject pickUpObject in fileClassroomObject.GetPickUpObjectList()) {
            Transform iconTransform = Instantiate(iconTemplate, transform);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<PaperIconSingleUI>().setPickUpObject(pickUpObject);
        }
    }
}