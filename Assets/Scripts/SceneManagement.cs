using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneManagement : MonoBehaviour
{
    private GameManager _gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void ReastartLevel()
    {
       _gameManager.RestartGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel() 
    {
        var index = PlayerPrefs.GetInt(TriggerFinish.LevelIndex);
        _gameManager.RestartGame();
        SceneManager.LoadScene(index);
    }
}