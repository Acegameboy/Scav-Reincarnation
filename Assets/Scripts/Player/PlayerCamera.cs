using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform Player; 
    public float smoothSpeed = 5f; 
    public Vector3 offset = new Vector3(0f, 0f, -10f); 

    private void LateUpdate()
    {
        if (Player == null) return;

        // Desired position
        Vector3 PlayerPosition = Player.position + offset;

        // Smoothly move towards the target position
        transform.position = Vector3.Lerp(transform.position, PlayerPosition, smoothSpeed * Time.deltaTime);
    }
}
