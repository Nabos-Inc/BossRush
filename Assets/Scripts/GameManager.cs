using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;

    public GameData data;

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadSceneGameOver(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
