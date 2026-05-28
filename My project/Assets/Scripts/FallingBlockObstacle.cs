using UnityEngine;

public class FallingBlockObstacle : MonoBehaviour
{
    private Rigidbody rb;
    private bool dropped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Drop()
    {
        if (dropped) return;

        dropped = true;
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}