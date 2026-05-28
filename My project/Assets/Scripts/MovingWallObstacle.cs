using UnityEngine;

public class MovingWallObstacle : MonoBehaviour
{
    public float speed = 3f;
    public float distance = 3f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(startPos.x + x, startPos.y, startPos.z);
    }
}