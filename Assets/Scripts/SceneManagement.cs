using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void ReastartLevel()
    {
        GameManager.Instance.RestartGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel() 
    {
        var index = PlayerPrefs.GetInt(TriggerFinish.LevelIndex);
        GameManager.Instance.RestartGame();
        SceneManager.LoadScene(index);
    }
}