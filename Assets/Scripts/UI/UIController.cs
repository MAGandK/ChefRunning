using UnityEngine;
public class UIController : MonoBehaviour
{
    private WindowBase[] _windows;
    
    private void OnEnable()
    {
        GameManager.IsPlayerDie += OnPlayerDie;
        GameManager.IsFinishGame += OnPlayerFinished;
        GameManager.IsStartGame += StartGame;
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
    
    private void StartGame()
    {
        ShowWindow(WindowType.MainWindow);
    }
    private void OnPlayerDie()
    {
        ShowWindow(WindowType.FailWindow);
    }
    
    private void OnPlayerFinished()
    {
       ShowWindow(WindowType.FinishWindow);
    }

    private void OnDisable()
    {
        GameManager.IsPlayerDie -= OnPlayerDie;
        GameManager.IsFinishGame -= OnPlayerFinished;
        GameManager.IsStartGame -= StartGame;
    }
}