using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BookToPaperSO : ScriptableObject
{

    public pickUpObject input;
    public pickUpObject output;
    public int studyingTime;
    public int printingTime;
}
