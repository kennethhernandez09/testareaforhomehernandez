using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraturn : MonoBehaviour
{
    public float turnSpeed = 100f; // Speed of the player rotation
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the keyboard
        float turnHorizontal = Input.GetAxis("Horizontal");

        // Calculate the rotation for this frame
        float rotation = turnHorizontal * turnSpeed * Time.deltaTime;

        // Apply the rotation to the player
        transform.Rotate(0, rotation, 0);
    }
}
