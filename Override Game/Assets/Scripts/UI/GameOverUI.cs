using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI noOfHomeworkSubmitted;
    [SerializeField] private Button mainMenuButton;

    private void Start() {
        OverrideGameManager.Instance.onGamestateChanged += OverrideGameManager_onGamestateChanged;
        hide();
    }

    private void Awake() {
        mainMenuButton.onClick.AddListener(() => {
            SceneManager.LoadScene("MainMenuScene");
        });
    }

    private void OverrideGameManager_onGamestateChanged(object sender, System.EventArgs e) {
        if (OverrideGameManager.Instance.isGameOver()) {
            show();
            mainMenuButton.Select();
            noOfHomeworkSubmitted.text = ScoreManager.Instance.getScore().ToString();
        } else {
            hide();
        }
    }

    private void show() {
        gameObject.SetActive(true);
    }

    private void hide() {
        gameObject.SetActive(false);
    }


}
