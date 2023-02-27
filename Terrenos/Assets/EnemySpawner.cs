using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Zombie Zombie;  // The enemy prefab to be spawned
    public int numEnemiesToSpawn = 3;  // The number of enemies to spawn at once
    public float spawnInterval = 800f;  // The time interval between enemy spawns
    private float timeSinceLastSpawn = 0f;  // The time elapsed since the last enemy spawn
    private int numEnemiesSpawned = 0;  // The number of enemies spawned in the current wave

    void Update()
    {
        // Increment the time since the last enemy spawn
        timeSinceLastSpawn += Time.deltaTime;

        // If the time since the last spawn is greater than or equal to the spawn interval...
        if (timeSinceLastSpawn >= spawnInterval)
        {
            // Reset the time since the last spawn
            timeSinceLastSpawn = 0f;
            numEnemiesSpawned = 0;

            // Spawn multiple instances of the enemy prefab at intervals
            StartCoroutine(SpawnEnemiesInterval());
        }
    }

    IEnumerator SpawnEnemiesInterval()
    {
        while (numEnemiesSpawned < numEnemiesToSpawn)
        {
            // Spawn an instance of the enemy prefab at the spawner's position and rotation
            Instantiate(Zombie, transform.position, transform.rotation);

            numEnemiesSpawned++;

            // Wait for 1 second before spawning the next enemy
            yield return new WaitForSeconds(spawnInterval / numEnemiesToSpawn);
        }
    }
}
