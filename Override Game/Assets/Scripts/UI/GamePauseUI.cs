using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour {

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake() {
        resumeButton.onClick.AddListener(() => {
            OverrideGameManager.Instance.TogglePause();
        });
        mainMenuButton.onClick.AddListener(() => {
            SceneManager.LoadScene("MainMenuScene");
        });
    }

    private void Start() {
        OverrideGameManager.Instance.onGamePause += OverrideGameManager_onGamePause;
        OverrideGameManager.Instance.onGameResume += OverrideGameManager_onGameResume;
        Hide();
    }

    private void OverrideGameManager_onGameResume(object sender, System.EventArgs e) {
        Hide();
    }

    private void OverrideGameManager_onGamePause(object sender, System.EventArgs e) {
        Show();
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }   
}
