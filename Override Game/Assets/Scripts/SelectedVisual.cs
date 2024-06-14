using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedVisual : MonoBehaviour
{

    [SerializeField] private Table table;
    [SerializeField] private GameObject visuals;
    [SerializeField] private GameObject visuals2;
    private void Start() {
        Character.Instance.SelectedTableChanging += Character_SelectedTableChanging;
    }

    private void Character_SelectedTableChanging(object sender, Character.SelectedTableChangingArgs e) {
        if (e.selectedTable == table) {
            Show();
        } else {
            Hide();
        }
    }

    private void Show() { 
        visuals.SetActive(true);
        visuals2.SetActive(true);
    }

    private void Hide() {
        visuals.SetActive(false);
        visuals2.SetActive(false);
    }
}
