using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public AudioSource BGMUSIC;
    public List<string> scenesToStopMusic; // List of scene names where music should stop

    void Start()
    {
        DontDestroyOnLoad(BGMUSIC);
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene is in the list of scenes where music should stop
        if (scenesToStopMusic.Contains(scene.name))
        {
            BGMUSIC.Stop(); // Stop the music
        }
    }

    // Ensure you unsubscribe from the event when the script is destroyed
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
