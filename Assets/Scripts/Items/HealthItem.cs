using UnityEngine;

public class HealthItem : ItemBehaviour
{
    [SerializeField]
    private float healAmount;

    public override void OnCollected(GameObject player)
    {
        player.GetComponent<HealthController>().AddHealth(healAmount);
    }
}
