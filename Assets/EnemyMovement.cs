using UnityEngine;
using TMPro;
public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
   

public PlayerMovement playerMovement;

void Start() {
    playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
}
    void Update()
    {
        // Move the enemy downward
        Vector3 pos = transform.position;
        pos.y -= speed * Time.deltaTime;
        transform.position = pos;

        // Destroy enemy if it moves off-screen
        if (pos.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(gameObject);
        }
    }

   public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            playerMovement.counter();
            Destroy(gameObject); // Destroy enemy
            Destroy(collision.gameObject); // Destroy the bullet
        }
        
    }
}
