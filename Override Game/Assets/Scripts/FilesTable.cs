using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FilesTable : Furniture {

    public event EventHandler OnFileLoaded;
    public event EventHandler OnFileUnloaded;   

    [SerializeField] private pickUpObject filePickUpObject;

    private float fileSpawnTime;

    private float fileSpawnTimeMax = 4f;

    private int filesCount;

    private int filesCountMax = 4;

    private void Update() {
        fileSpawnTime += Time.deltaTime;
        if (fileSpawnTime > fileSpawnTimeMax) {
            fileSpawnTime = 0f;

            if (filesCount < filesCountMax) {
                filesCount++;

                OnFileLoaded?.Invoke(this, EventArgs.Empty);
            }   
        }
    }

    public override void Interact(Character character) {
        if (!character.hasClassroomObject()) {
            if (filesCount > 0) {
                filesCount--;
                classroomObject.spawnClassroomObject(filePickUpObject, character);

                OnFileUnloaded?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
