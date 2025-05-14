using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;

    }

    public GameObject PausePanel;
    public GameObject PauseButton;
    public GameObject UnPauseButton;

    public FloatingTextManager floatingTextManager;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
        UnPauseButton.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
        UnPauseButton.SetActive(false);
        PauseButton.SetActive(true);
    }
}