using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign the Enemy prefab here
    public float spawnInterval = 2f; // Time between spawns
    public float spawnRangeX = 5f; // Horizontal range for spawning

    void Start()
    {
        // Spawn enemies repeatedly
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Calculate a random spawn position within the horizontal range
        float screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        float spawnX = Random.Range(-screenHalfWidth, screenHalfWidth);
        Vector3 spawnPosition = new Vector3(spawnX, Camera.main.orthographicSize + 1, 0);

        // Instantiate enemy
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
