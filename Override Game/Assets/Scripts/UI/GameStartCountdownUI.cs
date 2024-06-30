using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI countdownNumber;

    private void Start() {
        OverrideGameManager.Instance.onGamestateChanged += OverrideGameManager_onGamestateChanged;
        hide();
    }

    private void OverrideGameManager_onGamestateChanged(object sender, System.EventArgs e) {
        if (OverrideGameManager.Instance.isStartCountdown()) {
            show();
        } else {
            hide();
        }
    }

    private void Update() {
        countdownNumber.text = Mathf.Ceil(OverrideGameManager.Instance.getCountdownTimer()).ToString();
    }

    private void show() { 
        gameObject.SetActive(true);
    }

    private void hide() {
        gameObject.SetActive(false);
    }
}
