using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashbin : Furniture {

    public override void Interact(Character character) {
        if (character.hasClassroomObject()) {
            character.GetClassroomObject().removeObject();
        }
    }
}
