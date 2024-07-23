using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOptionsUI : MonoBehaviour {

    public static GameOptionsUI Instance { get; private set; }

    [SerializeField] private Button musicButton;
    [SerializeField] private Button soundEffectButton;
    [SerializeField] private Button closeButton;

    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI soundEffectText;

    [SerializeField] private Button upButton;
    [SerializeField] private Button downButton;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button useButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button controllerInteractButton;
    [SerializeField] private Button controllerUseButton;
    [SerializeField] private Button controllerPauseButton;

    [SerializeField] private TextMeshProUGUI upText;
    [SerializeField] private TextMeshProUGUI downText;
    [SerializeField] private TextMeshProUGUI leftText;
    [SerializeField] private TextMeshProUGUI rightText;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI useText;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private TextMeshProUGUI controllerInteractText;
    [SerializeField] private TextMeshProUGUI controllerUseText;
    [SerializeField] private TextMeshProUGUI controllerPauseText;

    [SerializeField] private Transform pressAKeyPromptTransform;

    private Action onCloseButtonAction;

    private void Awake() {
        Instance = this;

        musicButton.onClick.AddListener(() => {
            MusicManager.Instance.changeSound();
            UpdateVisual();
        });

        soundEffectButton.onClick.AddListener(() => {
            SoundEffect.Instance.changeSound();
            UpdateVisual();
        });

        closeButton.onClick.AddListener(() => {
            Hide();
            onCloseButtonAction();
        });

        upButton.onClick.AddListener(() => {
            rebind(GameInput.Binding.Up);
        });

        downButton.onClick.AddListener(() => {
            rebind(GameInput.Binding.Down);
        });

        leftButton.onClick.AddListener(() => {
            rebind(GameInput.Binding.Left);
        });

        rightButton.onClick.AddListener(() => {
            rebind(GameInput.Binding.Right);
        });

        interactButton.onClick.AddListener(() => {
            rebind(GameInput.Binding.Interact);
        });

        useButton.onClick.AddListener(() => {
            rebind(GameInput.Binding.Use);
        });

        pauseButton.onClick.AddListener(() => {
            rebind(GameInput.Binding.Pause);
        });
        controllerInteractButton.onClick.AddListener(() => {
            rebind(GameInput.Binding.ControllerInteract);
        });

        controllerUseButton.onClick.AddListener(() => {
            rebind(GameInput.Binding.ControllerUse);
        });

        controllerPauseButton.onClick.AddListener(() => {
            rebind(GameInput.Binding.ControllerPause);
        });
    }

    private void Start() {
        OverrideGameManager.Instance.onGameResume += OverrideGameManager_onGameResume;
        UpdateVisual();
        Hide();
        hidePressAKeyPrompt();
    }

    private void OverrideGameManager_onGameResume(object sender, System.EventArgs e) {
        Hide();
    }

    private void UpdateVisual() {
        soundEffectText.text = "Sound Effects: " + Mathf.Round(SoundEffect.Instance.getSound() * 10f);
        musicText.text = "Music: " + Mathf.Round(MusicManager.Instance.getSound() * 10f);

        upText.text = GameInput.Instance.getBinding(GameInput.Binding.Up);
        downText.text = GameInput.Instance.getBinding(GameInput.Binding.Down);
        leftText.text = GameInput.Instance.getBinding(GameInput.Binding.Left);
        rightText.text = GameInput.Instance.getBinding(GameInput.Binding.Right);
        interactText.text = GameInput.Instance.getBinding(GameInput.Binding.Interact);
        useText.text = GameInput.Instance.getBinding(GameInput.Binding.Use);
        pauseText.text = GameInput.Instance.getBinding(GameInput.Binding.Pause);
        controllerInteractText.text = GameInput.Instance.getBinding(GameInput.Binding.ControllerInteract);
        controllerUseText.text = GameInput.Instance.getBinding(GameInput.Binding.ControllerUse);
        controllerPauseText.text = GameInput.Instance.getBinding(GameInput.Binding.ControllerPause);
    }
    public void Show(Action onCloseButtonAction) {
        this.onCloseButtonAction = onCloseButtonAction;
        gameObject.SetActive(true);
        soundEffectButton.Select();
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void showPressAKeyPrompt() {
        pressAKeyPromptTransform.gameObject.SetActive(true);
    }

    public void hidePressAKeyPrompt() {
        pressAKeyPromptTransform.gameObject.SetActive(false);
    }

    private void rebind(GameInput.Binding binding) {
        showPressAKeyPrompt();

        GameInput.Instance.rebind(binding, () => {
            hidePressAKeyPrompt();
            UpdateVisual();
        });
    }
}
