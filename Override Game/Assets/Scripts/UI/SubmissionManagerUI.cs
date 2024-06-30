using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmissionManagerUI : MonoBehaviour
{

    [SerializeField] private Transform container;
    [SerializeField] private Transform homeworkTemplate;

    private void Awake() {
        homeworkTemplate.gameObject.SetActive(false);
    }

    private void Start() {
        SubmissionManager.Instance.onHomeworkSpawned += SubmissionManager_onHomeworkSpawned;
        SubmissionManager.Instance.onHomeworkCompleted += SubmissionManager_onHomeworkCompleted;
        updateVisual();
    }

    private void SubmissionManager_onHomeworkCompleted(object sender, System.EventArgs e) {
        updateVisual();
    }

    private void SubmissionManager_onHomeworkSpawned(object sender, System.EventArgs e) {
        updateVisual();
    }

    private void updateVisual() {
        foreach (Transform child in container) {
            if (child == homeworkTemplate) {
                continue;
            }
            Destroy(child.gameObject);
        }

        foreach (HomeworkSO homework in SubmissionManager.Instance.getWaitingHomeworkListSO()) {
            Transform homeworkTransform = Instantiate(homeworkTemplate, container);
            homeworkTransform.gameObject.SetActive(true);
            homeworkTransform.GetComponent<SubmissionManagerSingleUI>().setHomeworkName(homework);
        }
    }

}
