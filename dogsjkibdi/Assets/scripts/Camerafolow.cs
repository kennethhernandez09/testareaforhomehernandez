using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafolow : MonoBehaviour
{
    public Transform player;       // Reference to the player's transform
    public Vector3 offset;         // Offset from the player
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    void LateUpdate()
    {
        // Update the camera's position to follow the player
        transform.position = player.position + offset;
    }
}
