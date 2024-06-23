using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{

    [SerializeField] private Image bar;
    [SerializeField] private Printer printer;

    private void Start() {
        printer.BarProgressChanged += Printer_BarProgressChanged;
        bar.fillAmount = 0f;
    }

    private void Printer_BarProgressChanged(object sender, Printer.BarProgressChangedEventArgs e) {
        bar.fillAmount = e.progress;
    }
}
