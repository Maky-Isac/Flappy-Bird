using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BreakableWall") || other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (transform.position.x > Camera.main.transform.position.x + 20)
            Destroy(gameObject);
    }
}
