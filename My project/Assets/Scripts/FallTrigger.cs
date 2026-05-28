using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    public FallingBlockObstacle fallingBlock;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fallingBlock.Drop();
        }
    }
}