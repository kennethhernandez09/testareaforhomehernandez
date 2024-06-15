using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSkibidi : MonoBehaviour
{
    public float slideDistance = 1f; // Distance to slide downwards
    public float slideSpeed = 2f;    // Speed of sliding

    private bool isSliding = false;
    private Vector3 targetPosition;

    private bool isSpinning = false;

    public AudioClip audioClip; // The audio clip to play
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isSpinning)
        {
            StartCoroutine(SpinObjectCoroutine());
        }

        if (Input.GetKeyDown(KeyCode.E) && !isSliding)
        {
            targetPosition = transform.position - new Vector3(0, slideDistance, 0);
            isSliding = true;
        }

        if (isSliding)
        {
            float step = slideSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                isSliding = false;
                transform.position = targetPosition; // Snap to the target position
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayAudio();
        }
    }

    IEnumerator SpinObjectCoroutine()
    {
        isSpinning = true;

        float currentRotation = 0.0f;
        float targetRotation = 4000.0f;
        float rotationSpeed = 500.0f;

        while (currentRotation < targetRotation)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotationAmount, 0);
            currentRotation += rotationAmount;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0, 4000, 0);

        isSpinning = false;
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
