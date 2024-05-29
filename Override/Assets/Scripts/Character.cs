using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private float moveSpeed = 5.0f;
    void Update()
    {
        Vector2 coordinates = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.RightArrow)) {
            coordinates.x ++;
        } 
        if (Input.GetKey(KeyCode.LeftArrow)) {
            coordinates.x --;
        } 
        if (Input.GetKey(KeyCode.UpArrow)) {
            coordinates.y ++;
        } 
        if (Input.GetKey(KeyCode.DownArrow)) {
            coordinates.y --;
        } 

        coordinates = coordinates.normalized;
        Vector3 newPosition = new Vector3(coordinates.x, 0f, coordinates.y);
        transform.position += newPosition * Time.deltaTime * moveSpeed;
    }
}
