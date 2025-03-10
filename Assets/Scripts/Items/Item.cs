using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemBehaviour itemBehaviour;

    private void Awake()
    {
        itemBehaviour = GetComponent<ItemBehaviour>();

        if (itemBehaviour == null)
        {
            Debug.LogError($"No ItemBehaviour found on {gameObject.name}", gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement>();

        if (player != null && itemBehaviour != null)
        {
            itemBehaviour.OnCollected(player.gameObject);
            Destroy(gameObject);
        }
    }
}
