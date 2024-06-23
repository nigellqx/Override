using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : Furniture
{

    public override void Interact(Character character) {
        if (!hasClassroomObject()) {
            if (character.hasClassroomObject()) {
                character.GetClassroomObject().setParentObject(this);
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

}
