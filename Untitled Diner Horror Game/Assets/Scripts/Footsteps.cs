using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip footstepSound;
    public float footstepInterval = 0.5f; // Adjust the interval between footstep sounds
    private float nextFootstepTime;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource component is not attached, add it.
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        // Check if the player is moving and it's time for the next footstep sound
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            if (Time.time > nextFootstepTime)
            {
                PlayFootstepSound();
                nextFootstepTime = Time.time + footstepInterval;
            }
        }
    }

    private void PlayFootstepSound()
    {
        if (footstepSound != null)
        {
            audioSource.PlayOneShot(footstepSound);
        }
    }
}
