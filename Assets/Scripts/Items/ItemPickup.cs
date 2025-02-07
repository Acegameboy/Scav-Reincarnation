using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            PlayerScore.instance.AddScore(item.scoreValue); 
            Destroy(gameObject);
            Debug.Log($"Item {item.itemName} picked up")
        }
    }
}