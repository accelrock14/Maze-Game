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
        ResetTimeScale();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameIsPaused = true;
        gameOverMenu.SetActive(true);
    }

    public void GoBack()
    {
        ResetTimeScale();
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        ResetTimeScale();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void LoadLevels()
    {
        ResetTimeScale();
        SceneManager.LoadScene(1);
    }

    public void ResetTimeScale()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 1.0f;
        }
    }

    public void Victory()
    {
        WinScreen();
    }

    public void WinScreen()
    {
        gameIsPaused = true;
        Time.timeScale = 0.0f;
        winScreen.SetActive(true);
    }
}
