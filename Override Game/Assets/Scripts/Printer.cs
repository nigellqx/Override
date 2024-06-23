using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : Furniture
{

    public event EventHandler<BarProgressChangedEventArgs> BarProgressChanged;
    public class BarProgressChangedEventArgs : EventArgs {
        public float progress;
    }

    private float printingProgress;
    private float printDuration;
    private pickUpObject paperToPrint;
    private bool printing = false;

    private void Update() {
        if (printing) {
            printingProgress += Time.deltaTime;
            if (printingProgress > printDuration) {
                classroomObject.spawnClassroomObject(paperToPrint, this);
                Debug.Log("Printed!");
                printing = false;
            }
        }
    }

    public override void Interact(Character character) {
        if (!hasClassroomObject()) {
            if (character.hasClassroomObject()) {
                
            }
        } else {
            if (!character.hasClassroomObject()) {
                GetClassroomObject().setParentObject(character);
            } else {
                if (character.GetClassroomObject().TryGetFile(out FileClassroomObject fileClassroomObject)) {
                    if (fileClassroomObject.TryInsertPaper(GetClassroomObject().getPickUpObject())) {
                        GetClassroomObject().removeObject();
                    }
                }
            }
        }
    }

    public void beginPrinting(pickUpObject paperCreated, float duration) {
        Debug.Log("Printing!");
        paperToPrint = paperCreated;
        printDuration = duration;
        printingProgress = 0;
        printing = true;
    }

    public bool isPrinting() { 
        return printing; 
    }

}
