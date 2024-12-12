using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject enemyBulletPrefab; // Assign the EnemyBullet prefab here
    public Transform bulletSpawnPoint;  // Set the spawn point for bullets
    public float fireRate = 2f;         // Time between shots

    void Start()
    {
        // Shoot repeatedly
        InvokeRepeating("Shoot", 1f, fireRate);
    }

    void Shoot()
    {
        // Instantiate a bullet at the spawn point
        GameObject bullet = Instantiate(enemyBulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }
}
