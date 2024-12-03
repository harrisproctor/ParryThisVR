using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    // Tag of the object that should trigger the spawn
    public string targetTag = "TargetTag";

   private void OnCollisionEnter(Collision collision)
    {
     // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Get the SpawnablePrefabHolder component from the colliding object
            SpawnablePrefabHolder prefabHolder = collision.gameObject.GetComponent<SpawnablePrefabHolder>();

            // Check if the component is present and has a prefab assigned
            if (prefabHolder != null && prefabHolder.prefabToSpawn != null)
            {
                // Calculate the spawn position using the offset from the colliding object
                Vector3 spawnPosition = transform.position + prefabHolder.spawnOffset;
                int maxSeeds = prefabHolder.lifetime;
                int spawnNum = Random.Range(1, maxSeeds + 1);
                
                // Destroy the colliding object
                Destroy(collision.gameObject);

                // Instantiate the prefab at the calculated position with no rotation
               for (int i = 0; i < spawnNum; i++) 
                    {
                      Instantiate(prefabHolder.prefabToSpawn, spawnPosition, Quaternion.identity);
                    }
                
                
               
               
            }
        }
     }   
     
    
}
