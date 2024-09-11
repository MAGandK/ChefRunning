using UnityEngine;
using UnityEngine.UI;
public class FailWindow : WindowBace
{
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private SceneManagement _sceneManagement;
    public override WindowType Type
    {
        get
        {
            return WindowType.FailWindow;
        }
    }
    private void Start()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }
    private void OnRestartButtonClick()
    {
        _sceneManagement.ReastartLevel();
    }
}
