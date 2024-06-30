using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubmissionManagerSingleUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI homeworkName;
    [SerializeField] private Transform iconContainer;
    [SerializeField] private Transform iconTemplate;


    private void Awake() {
        iconTemplate.gameObject.SetActive(false);
    }

    public void setHomeworkName(HomeworkSO homework) {
        homeworkName.text = homework.homeworkName;

        foreach (Transform child in iconContainer) {
            if (child == iconTemplate) {
                continue;
            }
            Destroy(child.gameObject);
        }

        foreach (pickUpObject pickUpObject in homework.pickUpObjectList) {
            Transform paperTransform = Instantiate(iconTemplate, iconContainer);
            paperTransform.gameObject.SetActive(true);
            paperTransform.GetComponent<Image>().sprite = pickUpObject.sprite;
        }
    }

}
