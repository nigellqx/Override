using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashbin : Furniture {

    public static event EventHandler OnTrashed;

    new public static void resetStatic() {
        OnTrashed = null;
    }
    public override void Interact(Character character) {
        if (character.hasClassroomObject()) {
            character.GetClassroomObject().removeObject();

            OnTrashed?.Invoke(this, EventArgs.Empty);
        }
    }
}
