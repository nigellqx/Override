using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{

    [SerializeField] private Image bar;
    [SerializeField] private GameObject hasProgressGameObject;

    private IHasProgressBar hasProgress;

    private void Start() {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgressBar>();
        if (hasProgress == null) {
            Debug.LogError(hasProgressGameObject + "does not implement progress bar interface IHasProgressBar");
        }
        hasProgress.BarProgressChanged += HasProgress_BarProgressChanged;
        bar.fillAmount = 0f;
        hide();
    }

    private void HasProgress_BarProgressChanged(object sender, IHasProgressBar.BarProgressChangedEventArgs e) {
        bar.fillAmount = e.progress;

        if (e.progress == 0f || e.progress == 1f) {
            hide();
        } else {
            show();
        }
    }

    private void show() {
        gameObject.SetActive(true);
    }

    private void hide() {
        gameObject?.SetActive(false);
    }
}
