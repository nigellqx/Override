using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : Furniture, IHasProgressBar
{

    public event EventHandler<IHasProgressBar.BarProgressChangedEventArgs> BarProgressChanged;

    private float printingProgress;
    private float printDuration;
    private pickUpObject paperToPrint;
    private bool printing = false;

    private void Update() {
        if (printing) {
            printingProgress += Time.deltaTime;
            BarProgressChanged?.Invoke(this, new IHasProgressBar.BarProgressChangedEventArgs {
                progress = printingProgress / printDuration
            });
            if (printingProgress > printDuration) {
                classroomObject.spawnClassroomObject(paperToPrint, this);
                printing = false;
                BarProgressChanged?.Invoke(this, new IHasProgressBar.BarProgressChangedEventArgs {
                    progress = 0f
                });
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
        BarProgressChanged?.Invoke(this, new IHasProgressBar.BarProgressChangedEventArgs {
            progress = printingProgress / printDuration
        });
        paperToPrint = paperCreated;
        printDuration = duration;
        printingProgress = 0;
        printing = true;
    }

    public bool isPrinting() { 
        return printing; 
    }

}
