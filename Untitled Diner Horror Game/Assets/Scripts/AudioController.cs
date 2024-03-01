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

        audioSource = GetComponent<AudioSource>();

        if (backgroundMusic != null)
        {
            StartCoroutine(PlayMusicAfterDelay(12f));
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