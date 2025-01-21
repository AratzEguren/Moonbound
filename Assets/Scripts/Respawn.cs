using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform spawnPoint; // The location where the character will respawn
    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the character
        initialPosition = transform.position;
    }

     void OnTriggerEnter(Collider other)
    {
        // Check if the object the character collided with has the "Water" tag
        if (other.CompareTag("Water"))
        {
            RespawnCharacter();
        }
    }

    public void RespawnCharacter()
    {
        // Move the character to the spawn point
        transform.position = spawnPoint.position;
        // Optionally reset the character's rotation
        transform.rotation = spawnPoint.rotation;

        // Alternatively, move the character to its initial position if no spawn point is set
        transform.position = initialPosition;
    }

     
}