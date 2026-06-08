using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform player;

    public int currentLevel = 1;

    public float level1EndZ = 100f;
    public float level2EndZ = 220f;
    public float level3EndZ = 360f;

    public TextMeshProUGUI levelText;
    public GameObject winPanel;

    private bool gameWon = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentLevel = GameSettings.selectedLevel;

        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        UpdateLevelText();
    }

    void Update()
    {
        if (gameWon) return;

        if (player.position.z >= level3EndZ)
        {
            WinGame();
        }

        UpdateLevelText();
    }

    void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Level " + currentLevel;
        }
    }

    void WinGame()
    {
        gameWon = true;

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
    }
}