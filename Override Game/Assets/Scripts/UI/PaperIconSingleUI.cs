using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperIconSingleUI : MonoBehaviour {

    [SerializeField] private Image image;

    public void setPickUpObject(pickUpObject pickUpObject) {
        image.sprite = pickUpObject.sprite;
    }
}
