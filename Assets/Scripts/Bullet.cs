using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 75f; 

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has a HealthController
        HealthController health = collision.GetComponent<HealthController>();

        if (health != null)
        {
            health.TakeDamage(damage);

            if (health.RemainingHealthPercentage <= 0)
            {
                Destroy(collision.gameObject);
            }
        }

        Destroy(gameObject);
    }
}