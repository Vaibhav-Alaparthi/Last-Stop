using UnityEngine;
using TMPro;

public class PlayerPowerUps : MonoBehaviour
{
    public int coins = 0;
    public TextMeshProUGUI coinText;

    private PlayerMovement movement;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        UpdateCoinText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            UpdateCoinText();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("SpeedBoost"))
        {
            movement.SpeedBoost(4f, 5f);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("JumpBoost"))
        {
            movement.JumpBoost(3f, 5f);
            Destroy(other.gameObject);
        }
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }
    }
}