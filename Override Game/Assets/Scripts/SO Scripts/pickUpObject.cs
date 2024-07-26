using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class pickUpObject : ScriptableObject {

    public Transform prefab;

    public string objectName;

    public Sprite sprite;

    public int questionSet;
}
