using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameIsPaused = false;

    public GameObject gameOverMenu;
    public GameObject winScreen;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
    }

    public void GoBack()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void LoadLevels()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void Victory(int coins)
    {
        int level = LevelManager.currentLevel - 2;
        if(level == LevelManager.UnlockedLevels)
        {
            LevelManager.UnlockedLevels++;
            PlayerPrefs.SetInt("UnlockedLevels", LevelManager.UnlockedLevels);
        }
        
        if(coins > PlayerPrefs.GetInt("coins" + level.ToString(), 0))
        {
            PlayerPrefs.SetInt("coins" + level.ToString(), coins);
        }
        WinScreen();
    }

    public void WinScreen()
    {
        gameIsPaused = true;
        Time.timeScale = 0.0f;
        winScreen.SetActive(true);
    }
}
