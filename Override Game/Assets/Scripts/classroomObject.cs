using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classroomObject : MonoBehaviour {

    [SerializeField] private pickUpObject pickUpObject;

    private Table table;

    public pickUpObject getPickUpObject() {
        return pickUpObject;
    } 

    public void setTable(Table table) {
        if (this.table != null) {
            this.table.clearClassroomObject();
        }

        this.table = table;

        if (this.table.hasClassroomObject()) {
            Debug.LogError("Table already has an item");
        }

        table.setClassroomObject(this);

        transform.parent = table.getTableTopPoint();
        transform.localPosition = Vector3.zero; 
    }

    public Table getTable() {
        return table;
    }
}
