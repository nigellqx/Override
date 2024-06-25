using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmissionManager : MonoBehaviour {

    public event EventHandler onHomeworkSpawned;
    public event EventHandler onHomeworkCompleted;

    public static SubmissionManager Instance {  get; private set; }

    [SerializeField] private HomeworkListSO HomeworkListSO;
    private List<HomeworkSO> waitingHomeworkSOList;

    private float spawnHomeworkTimer;
    private float spawnHomeworkTimerMax = 5f;
    private int waitingHomeworkMax = 4;

    private void Awake() {
        Instance = this;
        waitingHomeworkSOList = new List<HomeworkSO>();
    }

    private void Update() {
        spawnHomeworkTimer -= Time.deltaTime;
        if (spawnHomeworkTimer <= 0f) {
            spawnHomeworkTimer = spawnHomeworkTimerMax;

            if (waitingHomeworkSOList.Count < waitingHomeworkMax) {
                HomeworkSO waitingHomeworkSO = HomeworkListSO.homeworkSOList[UnityEngine.Random.Range(0, HomeworkListSO.homeworkSOList.Count)];
                Debug.Log(waitingHomeworkSO.homeworkName);
                waitingHomeworkSOList.Add(waitingHomeworkSO);
                onHomeworkSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void SubmitHomework(FileClassroomObject fileClassroomObject) {
        for (int i = 0; i < waitingHomeworkSOList.Count; i++) {
            HomeworkSO waitingHomeworkSO = waitingHomeworkSOList[i];

            if (waitingHomeworkSO.pickUpObjectList.Count == fileClassroomObject.GetPickUpObjectList().Count) {
                bool FilePapersMatchesHomework = true;
                foreach (pickUpObject homeworkPickUpObject in waitingHomeworkSO.pickUpObjectList) {
                    bool paperFound = false;
                    foreach (pickUpObject filePickUpObject in fileClassroomObject.GetPickUpObjectList()) {
                        if (filePickUpObject == homeworkPickUpObject) {
                            paperFound = true;
                            break;
                        }
                    }
                    if (!paperFound) {
                        FilePapersMatchesHomework = false;
                    }
                }

                if (FilePapersMatchesHomework) {
                    Debug.Log("Correct");
                    waitingHomeworkSOList.RemoveAt(i);
                    onHomeworkCompleted?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }
        Debug.Log("Wrong");
    }

    public List<HomeworkSO> getWaitingHomeworkListSO() {
        return waitingHomeworkSOList;
    }
}
