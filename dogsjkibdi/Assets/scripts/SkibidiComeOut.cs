using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkibidiComeOut : MonoBehaviour
{
    private bool isMoving = false;

    public float rotationAngle = -360f; // Rotation angle in degrees
    public float rotationSpeed = 600f;  // Rotation speed in degrees per second

    private bool isRotating = false;
    private float totalRotation = 0f;

    public AudioClip audioClip; // The audio clip to play
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        // Add an AudioSource component to the GameObject if it doesn't already have one
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isMoving)
        {
            StartCoroutine(SlideObjectCoroutine());
        }

        if (Input.GetKeyDown(KeyCode.R) && !isRotating)
        {
            isRotating = true;
            totalRotation = 0f;
        }

        if (isRotating)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            totalRotation += rotationStep;

            if (totalRotation >= Mathf.Abs(rotationAngle))
            {
                rotationStep -= totalRotation - Mathf.Abs(rotationAngle);
                isRotating = false;
            }

            transform.Rotate(Vector3.up, -rotationStep);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayAudio();
        }
    }

    IEnumerator SlideObjectCoroutine()
    {
        isMoving = true;

        Vector3 startPos = transform.position;
        Vector3 targetPos = transform.position + Vector3.up; // Move upwards by 1 unit on Y-axis
        float duration = 1.0f; // Duration in seconds

        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float normalizedTime = (Time.time - startTime) / duration;
            transform.position = Vector3.Lerp(startPos, targetPos, normalizedTime);
            yield return null;
        }

        transform.position = targetPos; // Ensure we finish exactly at the target position

        isMoving = false;
    }
    void PlayAudio()
    {
        if (audioClip != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No audio clip assigned!");
        }
    }
}
