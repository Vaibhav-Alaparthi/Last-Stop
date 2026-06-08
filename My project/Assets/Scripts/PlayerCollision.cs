using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameUI gameUI;
    private PlayerPowerUps powerUps;

    void Start()
    {
        powerUps = GetComponent<PlayerPowerUps>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (powerUps != null && powerUps.hasShield)
            {
                powerUps.hasShield = false;
                Destroy(collision.gameObject);
                return;
            }
            SoundManager.instance.PlayDeath();
            gameUI.ShowGameOver();
        }
    }
}