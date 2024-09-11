using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void ReastartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel() 
    {
        var index = PlayerPrefs.GetInt(TriggerFinish.LevelIndex);
        SceneManager.LoadScene(index);
    }
}