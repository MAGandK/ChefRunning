using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishWindow : WindowBase
{
    [SerializeField]
    private SceneManagement _sceneManagement;
    private int levelIndex;

    public override WindowType Type
    {
        get
        {
            return WindowType.FinishWindow;
        }
    }

    public void OnNextButtonClick()
    {
       _sceneManagement.LoadNextLevel();
        var sceneName = SettingManager.Instance.LevelSettings.GetSceneName(levelIndex);
        SceneManager.LoadScene(sceneName);
    }
}
