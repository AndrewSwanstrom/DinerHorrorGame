using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController: MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Make sure an AudioClip is assigned
        if (backgroundMusic != null)
        {
            // Start the coroutine to play music after 10 seconds
            StartCoroutine(PlayMusicAfterDelay(10f));
        }
        else
        {
            Debug.LogError("Background Music AudioClip is not assigned!");
        }
    }

    IEnumerator PlayMusicAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Play the background music
        audioSource.clip = backgroundMusic;
        audioSource.Play();
    }
}