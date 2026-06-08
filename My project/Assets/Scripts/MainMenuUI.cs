using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        StartEasy();
    }

    public void StartEasy()
    {
        GameSettings.selectedLevel = 1;
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void StartMedium()
    {
        GameSettings.selectedLevel = 2;
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void StartHard()
    {
        GameSettings.selectedLevel = 3;
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void OpenShop()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ShopScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}