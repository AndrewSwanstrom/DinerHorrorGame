using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    private bool isOpen = false;
 
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the tag "Player" and the door is not already open
        if (!isOpen && collision.gameObject.CompareTag("Player"))
        {
            // Rotate the door 90 degrees to the right
            transform.Rotate(Vector3.up, 90.0f);
 
            // Set the flag to prevent further rotation
            isOpen = true;
        }
    }
}
