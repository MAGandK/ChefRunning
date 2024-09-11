using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishWindow : WindowBace
{
    [SerializeField]
    private Button _nextLevelButton;
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

    private void Start()
    {
        _nextLevelButton.onClick.AddListener(OnNextButtonClick);
    }

    private void OnNextButtonClick()
    {
       _sceneManagement.LoadNextLevel();
        var sceneName = SettingManager.Instance.LevelSettings.GetSceneName(levelIndex);
        SceneManager.LoadScene(sceneName);
    }
}
