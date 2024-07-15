using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOptionsUI : MonoBehaviour {

    [SerializeField] private Button musicButton;
    [SerializeField] private Button soundEffectButton;

    private void Awake() {
        musicButton.onClick.AddListener(() => {

        });
        soundEffectButton.onClick.AddListener(() => {

        });

    }
}
