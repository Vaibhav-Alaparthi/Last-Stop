using UnityEngine;

public static class CoinBank
{
    public static int TotalCoins
    {
        get
        {
            return PlayerPrefs.GetInt("TotalCoins", 0);
        }
        set
        {
            PlayerPrefs.SetInt("TotalCoins", value);
            PlayerPrefs.Save();
        }
    }

    public static int SelectedSkin
    {
        get
        {
            return PlayerPrefs.GetInt("SelectedSkin", 0);
        }
        set
        {
            PlayerPrefs.SetInt("SelectedSkin", value);
            PlayerPrefs.Save();
        }
    }

    public static bool OwnsSkin(int skin)
    {
        if (skin == 0)
            return true;

        return PlayerPrefs.GetInt("OwnsSkin_" + skin, 0) == 1;
    }

    public static void UnlockSkin(int skin)
    {
        PlayerPrefs.SetInt("OwnsSkin_" + skin, 1);
        PlayerPrefs.Save();
    }
}