using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTable : Furniture
{

    [SerializeField] private pickUpObject pickUpObject;

    public override void Interact(Character character) {
        if (!hasClassroomObject()) {
            if (character.hasClassroomObject()) {
                character.GetClassroomObject().setParentObject(this);
            }
        } else {
            if (!character.hasClassroomObject()) {
                GetClassroomObject().setParentObject(character);
            }
        }
    }

    public override void Use(Character character) {
        if (hasClassroomObject()) {
            GetClassroomObject().removeObject();
        }
    }

}
