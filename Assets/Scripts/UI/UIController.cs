using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    private WindowBase[] _windows;

    [Inject]

    private void Construct(Player player)
    {
        player.PlayerStateController.Died += PlayerOnDied;
    }

private void OnEnable()
    {
        GameManager.IsFinishGame += OnFinishGame;
        GameManager.IsStartGame += OnStartGame;
        GameManager.IsRestartGame += OnRestartGame;
    }

    private void Awake()
    {
        _windows = GetComponentsInChildren<WindowBase>(true);
    }


    private void PlayerOnDied()
    {
        ShowWindow(WindowType.FailWindow);
    }
    public void ShowWindow(WindowType type)
    {
        for (int i = 0; i < _windows.Length; i++)
        {
            if (_windows[i].Type == type)
            {
                _windows[i].ShowWindow();
            }
            else
            {
                _windows[i].CloseWindow();
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
        GameManager.IsFinishGame -= OnFinishGame;
        GameManager.IsStartGame -= OnStartGame;
        GameManager.IsRestartGame -= OnRestartGame;
    }
}