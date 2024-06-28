using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI noOfHomeworkSubmitted;

    private void Start() {
        OverrideGameManager.Instance.onGamestateChanged += OverrideGameManager_onGamestateChanged;
        hide();
    }

    private void OverrideGameManager_onGamestateChanged(object sender, System.EventArgs e) {
        if (OverrideGameManager.Instance.isGameOver()) {
            show();
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
