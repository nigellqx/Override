using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : Furniture {

    [SerializeField] private pickUpObject pickUpObject;
    
    public override void Interact(Character character) {
        if (!character.hasClassroomObject()) {
            classroomObject.spawnClassroomObject(pickUpObject, character);
        }
    }

   
}
