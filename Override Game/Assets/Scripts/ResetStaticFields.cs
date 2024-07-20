using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStaticFields : MonoBehaviour {

    private void Awake() {
        Furniture.resetStatic();
        Trashbin.resetStatic();
    }
}
