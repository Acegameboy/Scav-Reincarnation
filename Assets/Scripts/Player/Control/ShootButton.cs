using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerShoot shooter;

    public void OnPointerDown(PointerEventData eventData)
    {
        shooter.StartShooting();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        shooter.StopShooting();
    }
}
