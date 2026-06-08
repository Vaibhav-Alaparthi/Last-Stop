using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerPowerUps : MonoBehaviour
{
    public int coins = 0;
    public TextMeshProUGUI coinText;

    public bool hasShield = false;

    public GameObject powerUpPulse;

    private int activePowerUps = 0;
    private PlayerMovement movement;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();

        if (powerUpPulse != null)
        {
            powerUpPulse.SetActive(false);
        }

        UpdateCoinText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;

            CoinBank.TotalCoins += 1;

            UpdateCoinText();

            Destroy(other.gameObject);
        }

        if (other.CompareTag("SpeedBoost"))
        {
            StartCoroutine(SpeedBoostRoutine());
            Destroy(other.gameObject);
        }

        if (other.CompareTag("JumpBoost"))
        {
            StartCoroutine(JumpBoostRoutine());
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Shield"))
        {
            if (SoundManager.instance != null)
            {
                SoundManager.instance.PlayShield();
            }

            StartCoroutine(ShieldRoutine());
            Destroy(other.gameObject);
        }
    }

    IEnumerator SpeedBoostRoutine()
    {
        StartPowerUpVisual();

        movement.SpeedBoost(4f, 5f);

        yield return new WaitForSeconds(5f);

        StopPowerUpVisual();
    }

    IEnumerator JumpBoostRoutine()
    {
        StartPowerUpVisual();

        movement.JumpBoost(2f, 4f);

        yield return new WaitForSeconds(5f);

        StopPowerUpVisual();
    }

    IEnumerator ShieldRoutine()
    {
        StartPowerUpVisual();

        hasShield = true;

        while (hasShield)
        {
            yield return null;
        }

        StopPowerUpVisual();
    }

    void StartPowerUpVisual()
    {
        activePowerUps++;

        if (powerUpPulse != null)
        {
            powerUpPulse.SetActive(true);
        }
    }

    void StopPowerUpVisual()
    {
        activePowerUps--;

        if (activePowerUps <= 0)
        {
            activePowerUps = 0;

            if (powerUpPulse != null)
            {
                powerUpPulse.SetActive(false);
            }
        }
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + CoinBank.TotalCoins;
        }
    }
}