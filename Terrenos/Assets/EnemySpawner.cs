using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Zombie Zombie;  // The enemy prefab to be spawned
    // public int numEnemiesToSpawn = 3;  // The number of enemies to spawn at once
    // public float spawnInterval = 800f;  // The time interval between enemy spawns
    // private float timeSinceLastSpawn = 0f;  // The time elapsed since the last enemy spawn
    // private int numEnemiesSpawned = 0;  // The number of enemies spawned in the current wave
    public int zombiesPerWave = 7;
    public float timeBetweenWaves = 120f;
    private int zombiesSpawned = 0;

    void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    private IEnumerator SpawnZombies()
    {
       while (true)
        {
            if (zombiesSpawned < zombiesPerWave)
            {
                Instantiate(Zombie, transform.position, Quaternion.identity);
                zombiesSpawned++;
            }
            else
            {
                zombiesSpawned = 0;
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
    }
}
