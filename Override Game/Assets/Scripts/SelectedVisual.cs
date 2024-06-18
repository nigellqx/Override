using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedVisual : MonoBehaviour
{

    [SerializeField] private Furniture furniture;
    [SerializeField] private GameObject[] visualsArray;
    private void Start() {
        Character.Instance.SelectedTableChanging += Character_SelectedTableChanging;
    }

    private void Character_SelectedTableChanging(object sender, Character.SelectedTableChangingArgs e) {
        if (e.selectedFurniture == furniture) {
            Show();
        } else {
            Hide();
        }
    }

    private void Show() {
        foreach (GameObject visual in visualsArray) {
            visual.SetActive(true);
        }
    }

    private void Hide() {
        foreach (GameObject visual in visualsArray) {
            visual.SetActive(false);
        }
    }
}
