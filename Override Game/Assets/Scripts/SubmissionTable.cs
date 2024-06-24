using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmissionTable : Furniture {

    public override void Interact(Character character) {
        if (character.hasClassroomObject()) {
            if (character.GetClassroomObject().TryGetFile(out FileClassroomObject fileClassroomObject)) {
                character.GetClassroomObject().removeObject();
            }
        }
    }
}
