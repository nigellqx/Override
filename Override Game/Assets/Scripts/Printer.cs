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

    private int printerDuration = 5;
    private int printingProgress;

    public override void Interact(Character character) {
        if (!hasClassroomObject()) {
            if (character.hasClassroomObject()) {
                character.GetClassroomObject().setParentObject(this);

                printingProgress = 0;
                BarProgressChanged?.Invoke(this, new BarProgressChangedEventArgs {
                    progress = (float) printingProgress / printerDuration
                });
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

    public override void Use(Character character) {
        printingProgress += 1;
        if (printingProgress > printerDuration) {
            printingProgress = 0;
        }
        BarProgressChanged?.Invoke(this, new BarProgressChangedEventArgs {
            progress = (float)printingProgress / printerDuration
        });
    }

}
