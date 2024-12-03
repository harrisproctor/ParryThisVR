using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnCollision : MonoBehaviour
{
    // Tag of the object that should trigger the spawn
    public string targetTag = "TargetTag";
    bool enabled = true;

    void Disable(float time)
    {
        enabled = false;
        // If we were called multiple times, reset timer.
        CancelInvoke("Enable"); 
        // Note: Even if we have disabled the script, Invoke will still run.
        Invoke("Enable", time);
    }

    void Enable()
    {
        enabled = true;
    }


    // Method called when this object collides with another collider
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag(targetTag) && enabled == true)
        {
            // Get the SpawnablePrefabHolder component from the colliding object
            SpawnablePrefabHolder prefabHolder = collision.gameObject.GetComponent<SpawnablePrefabHolder>();

            // Check if the component is present and has a prefab assigned
            if (prefabHolder != null && prefabHolder.prefabToSpawn != null)
            {
                // Calculate the spawn position using the offset from the colliding object
                Vector3 spawnPosition = transform.position + prefabHolder.spawnOffset;
                int lifetime = prefabHolder.lifetime;

                // Instantiate the prefab at the calculated position with no rotation
                GameObject plant = Instantiate(prefabHolder.prefabToSpawn, spawnPosition, Quaternion.identity);
                // Destroy the colliding object
                Destroy(collision.gameObject);
                Destroy(plant, lifetime);
                Disable(lifetime);
               
                
            }
        }
    }
}

