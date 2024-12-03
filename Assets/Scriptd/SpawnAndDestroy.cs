using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndDestroy : MonoBehaviour
{
    // The prefab to spawn
    public GameObject prefabToSpawn;

    // The interval in seconds between spawns
    public float spawnInterval = 1.0f;

    // Minimum and maximum number of objects to spawn before destroying this object
    public int minSpawnCount = 5;
    public int maxSpawnCount = 10;

    // Minimum and maximum offset ranges for spawning the prefab
    public Vector3 minSpawnOffset = Vector3.zero;
    public Vector3 maxSpawnOffset = Vector3.zero;

    // Internal counter for the number of spawned objects
    private int spawnCount = 0;

    // The randomly determined number of objects to spawn before destruction
    private int targetSpawnCount;

    // Start is called before the first frame update
    void Start()
    {
        // Determine the random target spawn count
        targetSpawnCount = Random.Range(minSpawnCount, maxSpawnCount + 1);

        // Start the spawning process
        InvokeRepeating("SpawnObject", spawnInterval, spawnInterval);
    }

    // Method to spawn the prefab
    void SpawnObject()
    {
        // Calculate the random spawn position within the specified offset range
        Vector3 spawnPosition = new Vector3(
            Random.Range(minSpawnOffset.x, maxSpawnOffset.x),
            Random.Range(minSpawnOffset.y, maxSpawnOffset.y),
            Random.Range(minSpawnOffset.z, maxSpawnOffset.z)
        ) + transform.position;

        // Instantiate the prefab at the calculated position and with the same rotation as the current object
        Instantiate(prefabToSpawn, spawnPosition, transform.rotation);

        // Increment the spawn counter
        spawnCount++;

        // Check if the target spawn count has been reached
        if (spawnCount >= targetSpawnCount)
        {
            // Stop the spawning process
            CancelInvoke("SpawnObject");

        }
    }
}
