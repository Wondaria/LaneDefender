using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minSpawnInterval; // Minimum spawn interval (in seconds)
    [SerializeField] private float maxSpawnInterval; // Maximum spawn interval (in seconds)
    [SerializeField] private Transform spawnPoint;

    private float nextSpawnTime; // Time when the next enemy should spawn

    /// <summary>
    /// Calls the method at start
    /// </summary>
    void Start()
    {
        // Set the first spawn time
        SetNextSpawnTime();
    }

    /// <summary>
    /// Spawns Enemys
    /// </summary>
    void Update()
    {
        // Check if it's time to spawn a new enemy
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            SetNextSpawnTime();  // Set the time for the next spawn
        }
    }

    /// <summary>
    /// Spawns an enemy
    /// </summary>
    void SpawnEnemy()
    {
        // Instantiate the enemy at the spawn point
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

    /// <summary>
    /// Sets the next spawn time
    /// </summary>
    void SetNextSpawnTime()
    {
        // Randomly pick a spawn interval between min and max
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}
