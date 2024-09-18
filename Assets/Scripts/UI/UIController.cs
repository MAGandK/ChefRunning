using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    private WindowBace[] _windows;
    private GameManager _gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
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