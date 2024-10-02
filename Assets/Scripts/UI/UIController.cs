using UnityEngine;
public class UIController : MonoBehaviour
{
    private WindowBase[] _windows;
    
    private void OnEnable()
    {
        GameManager.IsPlayerDie += OnPlayerDie;
        GameManager.IsFinishGame += OnFinishGame;
        GameManager.IsStartGame += OnStartGame;
        GameManager.IsRestartGame += OnRestartGame;
    }

    private void Awake()
    {
        _windows = GetComponentsInChildren<WindowBase>(true);
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

    public WindowBase GetWindow(WindowType type)
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
    
    private void OnStartGame()
    {
        ShowWindow(WindowType.MainWindow);
    }
    private void OnPlayerDie()
    {
        ShowWindow(WindowType.FailWindow);
    }
    
    private void OnFinishGame()
    {
       ShowWindow(WindowType.FinishWindow);
    }
    
    private void OnRestartGame()
    {
        ShowWindow(WindowType.MainWindow);
    }

    private void OnDisable()
    {
        GameManager.IsPlayerDie -= OnPlayerDie;
        GameManager.IsFinishGame -= OnFinishGame;
        GameManager.IsStartGame -= OnStartGame;
        GameManager.IsRestartGame -= OnRestartGame;
    }
}