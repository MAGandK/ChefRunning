using UnityEngine;
public class UIController : MonoBehaviour
{
    private WindowBace[] _windows;
    private WindowType Type;
    private void Awake()
    {
        _windows = GetComponentsInChildren<WindowBace>(true);
    }
    private void Start()
    {
        ShowWindow(WindowType.MainWindow);
    }
    public void ShowWindow(WindowType type)
    {
        for (int i = 0; i < _windows.Length; i++)
        {
            if (_windows[i].Type == type)
            {
                _windows[i].Show();
            }
            else
            {
                _windows[i].Hide();
            }
        }
    }

    public WindowBace GetWindow(WindowType type)
    {
        for (int i = 0; i < _windows.Length; i++)
        {
            if (_windows[i].Type == type)
            {
                return _windows[i];
            }
        }

        return null;
    }
}