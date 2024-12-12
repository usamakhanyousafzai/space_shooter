using UnityEngine;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 3f;
     public float pointer = 0;
    public TextMeshProUGUI points; 
    public float playerBoundaryRadius = 0.5f;
    public GameObject playerBulletPrefab; // Drag and drop the PlayerBullet prefab here
    public Transform bulletSpawnPosition1; // Assign first bullet spawn point
    public Transform bulletSpawnPosition2; // Assign second bullet spawn point
    public AudioClip soundClip; // Assign in the Inspector or dynamically via code
    public AudioSource audioSource;
void Start() {

}
public void counter()
{
    pointer +=1; 
        points.text = pointer.ToString(); 
}

    void Update()
    {
        // Movement
        // Get the current position of the player
        Vector3 pos = transform.position;

        // Move left and right based on horizontal input
        pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;

        // Move up and down based on vertical input
        pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;

        // Restrict movement to the camera boundaries
        float screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;

        // Horizontal boundaries
        if (pos.x + playerBoundaryRadius > screenHalfWidth)
        {
            pos.x = screenHalfWidth - playerBoundaryRadius;
        }
        if (pos.x - playerBoundaryRadius < -screenHalfWidth)
        {
            pos.x = -screenHalfWidth + playerBoundaryRadius;
        }

        // Vertical boundaries
        if (pos.y + playerBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - playerBoundaryRadius;
        }
        if (pos.y - playerBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + playerBoundaryRadius;
        }

        // Apply the calculated position back to the player
        transform.position = pos;
         // Shoot bullets when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {   audioSource.Play();
            GameObject bullet1 = Instantiate(playerBulletPrefab);
            bullet1.transform.position = bulletSpawnPosition1.position;

            GameObject bullet2 = Instantiate(playerBulletPrefab);
            bullet2.transform.position = bulletSpawnPosition2.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject); // Destroy player
            Destroy(other.gameObject); // Destroy the bullet
        }
    }
}
