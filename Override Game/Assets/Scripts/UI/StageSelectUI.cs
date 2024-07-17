using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectUI : MonoBehaviour
{

    [SerializeField] private Button backButton;
    [SerializeField] private Button classroomButton;

    private void Awake() {
        backButton.onClick.AddListener(() => {
            Hide();
        });

        classroomButton.onClick.AddListener(() => {
            SceneManager.LoadScene("GameScene");
        });

        Hide();
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

}
