using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTable : Furniture
{

    [SerializeField] private pickUpObject[] bookList;
    public override void Interact(Character character) {
        if (!hasClassroomObject()) {
            if (character.hasClassroomObject()) {
                if (hasBook(character.GetClassroomObject().getPickUpObject())) {
                    character.GetClassroomObject().setParentObject(this);
                }
            }
        } else {
            if (!character.hasClassroomObject()) {
                GetClassroomObject().setParentObject(character);
            }
        }
    }

    public override void Use(Character character) {
        if (hasClassroomObject() && hasBook(GetClassroomObject().getPickUpObject())) {
            GetClassroomObject().removeObject();
        }
    }

    private bool hasBook(pickUpObject itemOnTable) {
        foreach (pickUpObject book in bookList) {
            if (book == itemOnTable) {
                return true;
            }
        }
        return false;
    }
}
