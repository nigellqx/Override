using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmissionTable : Furniture {

    public static SubmissionTable Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    public override void Interact(Character character) {
        if (character.hasClassroomObject()) {
            if (character.GetClassroomObject().TryGetFile(out FileClassroomObject fileClassroomObject)) {
                
                SubmissionManager.Instance.SubmitHomework(fileClassroomObject);
                character.GetClassroomObject().removeObject();
            }
        }
    }
}
