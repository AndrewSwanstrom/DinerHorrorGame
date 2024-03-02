using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSanityController : MonoBehaviour
{
    public float initialSanity = 200f;
    public float sanityDecreaseRate = 2f;
    public float currentSanity;
    
    public float interactionRange = 3f;
    public KeyCode interactionKey = KeyCode.E;
    public Color highlightColor = Color.green;

    private List<WaterCup> waterCups = new List<WaterCup>();
    private WaterCup currentWaterCup;

    void Start()
    {
        currentSanity = initialSanity;
        Debug.Log(currentSanity);
        InvokeRepeating("DecreaseSanity", 2f, 2f);

        waterCups.AddRange(FindObjectsOfType<WaterCup>());
    }

    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            PickUpWaterCup();;
        }
        CheckForWaterCup();
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

    public void GainSanity(int amount)
    {
        currentSanity += amount;
    }

    public void OnItemPickup(GameObject cupObject)
    {
        Debug.Log("u picked up the water cup");
        waterCups.Remove(cupObject.GetComponent<WaterCup>());
        GainSanity(10);
        Destroy(cupObject);
    }

    void CheckForWaterCup()
    {
        waterCups.RemoveAll(cup => cup == null);

        if (waterCups.Count > 0)
        {
            WaterCup closestWaterCup = FindClosestWaterCup();

          
            if (closestWaterCup != null && closestWaterCup != currentWaterCup)
            {
                if (currentWaterCup != null)
                {
                    currentWaterCup.ResetColor();
                }

                currentWaterCup = closestWaterCup;
                currentWaterCup.HighlightCup(highlightColor);
                Debug.Log("In interaction range with water cup...");
            }
            else if (closestWaterCup == null && currentWaterCup != null)
            {
               if (currentWaterCup.gameObject != null)
                {
                    currentWaterCup.ResetColor();
                }
                currentWaterCup = null;
            }
        }
    }

    void PickUpWaterCup()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange))
        {
            GameObject hitObject = hit.collider.gameObject;
        
            if (hitObject.CompareTag("WaterCup")) 
                {
                    Debug.Log("If statement hit");
                    OnItemPickup(hitObject); 
                }
        }
    }

    WaterCup FindClosestWaterCup()
    {
        WaterCup closestWaterCup = null;
        float closestDistance = float.MaxValue;

        foreach (WaterCup waterCup in waterCups)
        {
            float distance = Vector3.Distance(transform.position, waterCup.transform.position);

            if (distance <= interactionRange && distance < closestDistance)
            {
                closestWaterCup = waterCup;
                closestDistance = distance;
            }
        }

        return closestWaterCup;
    }
}