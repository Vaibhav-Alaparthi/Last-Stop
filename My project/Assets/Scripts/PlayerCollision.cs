using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameUI gameUI;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameUI.ShowGameOver();
        }
    }
}