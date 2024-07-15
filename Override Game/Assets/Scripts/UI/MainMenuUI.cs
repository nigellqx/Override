using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Transform instructionUI;

    private void Awake() {
        playButton.onClick.AddListener(() => {
            SceneManager.LoadScene("GameScene");
        });

        controlsButton.onClick.AddListener(() => {
            instructionUI.gameObject.SetActive(true);
        });

        backButton.onClick.AddListener(() => {
            instructionUI.gameObject.SetActive(false);
        });

        quitButton.onClick.AddListener(() => { 
            Application.Quit();
        });

        Time.timeScale = 1f;
    }

}
