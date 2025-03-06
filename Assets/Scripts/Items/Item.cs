using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemBehaviour itemBehaviour;

    private void Awake()
    {
        itemBehaviour = GetComponent<ItemBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement>();

        if (player != null)
        {
            itemBehaviour.OnCollected(player.gameObject);
            Destroy(gameObject);
        }
    }
}
