using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectUI : MonoBehaviour
{

    [SerializeField] private Button backButton;
    [SerializeField] private Button classroomButton;
    [SerializeField] private Button playButton;

    public static StageSelectUI Instance { get; private set; }

        private void Awake() {
        Instance = this;
        backButton.onClick.AddListener(() => {
            Hide();
        });

        classroomButton.onClick.AddListener(() => {
            SceneManager.LoadScene("GameScene");
        });

        Hide();
    }

    public void Show() {
        gameObject.SetActive(true);
        classroomButton.Select();
    }

    private void Hide() {
        playButton.Select();
        gameObject.SetActive(false);
    }

}
