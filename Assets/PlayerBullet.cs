using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletSpeed = 8f;
   
    void Update()
    {
        // Move bullet upward
      
       
        Vector3 pos = transform.position;
        pos.y += bulletSpeed * Time.deltaTime;
        transform.position = pos;

        // Destroy bullet when it goes off-screen
        Vector3 maxPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        if (transform.position.y > maxPosition.y)
        {
            Destroy(gameObject);
        }

        
    }
}
