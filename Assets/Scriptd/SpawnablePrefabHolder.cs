using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnablePrefabHolder : MonoBehaviour
{
  // Assign the prefab to spawn in the Inspector
    public GameObject prefabToSpawn;

     // Assign the spawn offset in the Inspector
    public Vector3 spawnOffset = Vector3.zero;

    // Assign the spawn offset in the Inspector
    public int lifetime;
}
