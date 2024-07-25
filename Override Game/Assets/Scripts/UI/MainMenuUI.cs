using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button instructionsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button back2Button;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Transform instructionUI;
    [SerializeField] private Transform howToPlayUI;

    private void Awake() {
        playButton.onClick.AddListener(() => {
            StageSelectUI.Instance.Show();
        });

        instructionsButton.onClick.AddListener(() => {
            instructionUI.gameObject.SetActive(true);
            backButton.Select();
            nextButton.Select();
        });

        backButton.onClick.AddListener(() => {
            instructionUI.gameObject.SetActive(false);
            playButton.Select();
        });

        quitButton.onClick.AddListener(() => { 
            Application.Quit();
        });

        nextButton.onClick.AddListener(() => {
            howToPlayUI.gameObject.SetActive(true);
            instructionUI.gameObject.SetActive(false);
            back2Button.Select();
            closeButton.Select();
        });

        back2Button.onClick.AddListener(() => {
            howToPlayUI.gameObject.SetActive(false);
            instructionUI.gameObject.SetActive(true);
            backButton.Select();
            nextButton.Select();
        });

        closeButton.onClick.AddListener(() => {
            howToPlayUI.gameObject.SetActive(false);
            playButton.Select();
        });

        Time.timeScale = 1f;
    }

}
