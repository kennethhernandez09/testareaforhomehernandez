using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player movement
    public float turnSpeed = 100f; // Speed of the player rotation
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the keyboard
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector3 movement = new Vector3(0, 0, moveVertical);

        // Normalize the movement vector to ensure consistent speed
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        // Move the player
        transform.Translate(movement);

        // Get input from the keyboard
        float turnHorizontal = Input.GetAxis("Horizontal");

        // Calculate the rotation for this frame
        float rotation = turnHorizontal * turnSpeed * Time.deltaTime;

        // Apply the rotation to the player
        transform.Rotate(0, rotation, 0);
    }
}
