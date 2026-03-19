using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, 5f, -7f);
    public float smoothSpeed = 8f;

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        transform.LookAt(player.position + new Vector3(0f, 1.5f, 0f));
    }
}