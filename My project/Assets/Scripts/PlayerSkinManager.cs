using UnityEngine;

public class PlayerSkinManager : MonoBehaviour
{
    public Renderer playerRenderer;
    public Material[] skins;

    void Start()
    {
        int selectedSkin = CoinBank.SelectedSkin;

        if (playerRenderer != null && skins.Length > selectedSkin)
        {
            playerRenderer.material = skins[selectedSkin];
        }
    }
}