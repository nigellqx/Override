using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterPrintingSound : MonoBehaviour {

    [SerializeField] private Printer printer;
    [SerializeField] private AudioClip audioClip;

   
    private void Update() {
        if (printer.isPrinting()) {
            float volume = 100f;
            AudioSource.PlayClipAtPoint(audioClip, printer.transform.position, volume);
        }
    }
}
