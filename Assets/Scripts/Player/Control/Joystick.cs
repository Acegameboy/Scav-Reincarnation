using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public MoveDirection direction;
    public PlayerMovement playerMovement;

    public void OnPointerDown(PointerEventData eventData)
    {
        playerMovement.SetMove(direction, true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerMovement.SetMove(direction, false);
    }
}
