using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField]
    private float healAmount;

    public void OnColloect(GameObject player)
    {
        player.GetComponent<HealthController>().AddHealth(healAmount);
    }
}
