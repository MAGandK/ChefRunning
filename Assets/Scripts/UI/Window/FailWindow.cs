using UnityEngine;
using UnityEngine.UI;
public class FailWindow : WindowBase
{
    [SerializeField]
    private SceneManagement _sceneManagement;
    public override WindowType Type
    {
        get
        {
            return WindowType.FailWindow;
        }
    }
    public void OnRestartButtonClick()
    {
        _sceneManagement.ReastartLevel();
    }
}
