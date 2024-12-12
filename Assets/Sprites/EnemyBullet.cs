    using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed = 5f; // Speed of the bullet

    void Update()
    {
        // Move the bullet downward
        Vector3 pos = transform.position;
        pos.y -= bulletSpeed * Time.deltaTime;
        transform.position = pos;

        // Destroy the bullet if it moves off-screen
        if (pos.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(gameObject);
        }
    }
}
