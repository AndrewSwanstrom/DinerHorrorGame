using UnityEngine;

public class DoorMan : MonoBehaviour
{
    // Reference to the object to be hidden
    public GameObject DoorOpen;

    // Reference to the object to be activated
    public GameObject DoorClosed;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with the player (you might need to adjust the tag or layer)
        if (other.CompareTag("Player"))
        {
            // Hide the current object
            if (DoorOpen != null)
            {
                DoorOpen.SetActive(false);
            }

            // Show/activate the target object
            if (DoorClosed != null)
            {
                DoorClosed.SetActive(true);
            }
        }
    }
}
