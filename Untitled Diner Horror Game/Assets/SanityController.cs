using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityController : MonoBehaviour
{
    private float initialSanity = 200f;
    private float currentSanity;
    private float sanityDecreaseRate = 10f;

    void Start()
    {
        currentSanity = initialSanity;
        InvokeRepeating("DecreaseSanity", 2f, 2f);
    }

    void Update()
    {
        Debug.Log(currentSanity);
    }

    void DecreaseSanity()
    {
        currentSanity -= sanityDecreaseRate;

        if (currentSanity <= 0)
        {
            currentSanity = 0;
            GameOver(); 
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
    }

    void GainSanity(int amount)
    {
        currentSanity += amount;
    }

    public void OnItemPickup()
    {
        GainSanity(10);
        Debug.Log("Gained 10 sanity");
    }
}
