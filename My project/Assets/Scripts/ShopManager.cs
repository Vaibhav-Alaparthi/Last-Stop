using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI redButtonText;
    public TextMeshProUGUI blueButtonText;

    public int redSkinCost = 10;
    public int blueSkinCost = 20;

    void Start()
    {
        RefreshUI();
    }

    void RefreshUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + CoinBank.TotalCoins;
        }

        if (redButtonText != null)
        {
            redButtonText.text = CoinBank.OwnsSkin(1)
                ? "Red Skin Owned"
                : "Red Skin (10 Coins)";
        }

        if (blueButtonText != null)
        {
            blueButtonText.text = CoinBank.OwnsSkin(2)
                ? "Blue Skin Owned"
                : "Blue Skin (20 Coins)";
        }
    }

    public void SelectDefault()
    {
        CoinBank.SelectedSkin = 0;
        RefreshUI();
    }

    public void BuyRedSkin()
    {
        if (CoinBank.OwnsSkin(1))
        {
            CoinBank.SelectedSkin = 1;
            RefreshUI();
            return;
        }

        if (CoinBank.TotalCoins >= redSkinCost)
        {
            CoinBank.TotalCoins -= redSkinCost;
            CoinBank.UnlockSkin(1);
            CoinBank.SelectedSkin = 1;
            RefreshUI();
        }
    }

    public void BuyBlueSkin()
    {
        if (CoinBank.OwnsSkin(2))
        {
            CoinBank.SelectedSkin = 2;
            RefreshUI();
            return;
        }

        if (CoinBank.TotalCoins >= blueSkinCost)
        {
            CoinBank.TotalCoins -= blueSkinCost;
            CoinBank.UnlockSkin(2);
            CoinBank.SelectedSkin = 2;
            RefreshUI();
        }
    }

    public void Back()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}