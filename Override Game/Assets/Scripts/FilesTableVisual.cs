using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilesTableVisual : MonoBehaviour {

    [SerializeField] private FilesTable fileTable;

    [SerializeField] private Transform fileTableTopPoint;

    [SerializeField] private Transform filesPrefab;

    private List<GameObject> fileVisualGameObjectList;

    private void Awake() {
        fileVisualGameObjectList = new List<GameObject>();
    }
    private void Start() {
        fileTable.OnFileLoaded += FileTable_OnFileLoaded;
        fileTable.OnFileUnloaded += FileTable_OnFileUnloaded;
    }

    private void FileTable_OnFileUnloaded(object sender, System.EventArgs e) {
        GameObject fileGameObject = fileVisualGameObjectList[fileVisualGameObjectList.Count - 1];
        fileVisualGameObjectList.Remove(fileGameObject);
        Destroy(fileGameObject);
    }

    private void FileTable_OnFileLoaded(object sender, System.EventArgs e) {
        Transform fileVisualTransform = Instantiate(filesPrefab, fileTableTopPoint);

        float fileVisualOffSet = .2f;
        fileVisualTransform.localPosition = new Vector3(fileVisualOffSet * fileVisualGameObjectList.Count, 0, 0);

        fileVisualGameObjectList.Add(fileVisualTransform.gameObject);
    }
}
