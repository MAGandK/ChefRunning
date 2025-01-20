using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    private WindowBase[] _windows;
    
    private Player _player;
    private GameManager _gameManager;
    
    [Inject]

    private void Construct(Player player, GameManager gameManager)
    {
        _player = player;
        _gameManager = gameManager;
    }

private void OnEnable()
    {
        _player.Died += PlayerOnDied;
        _gameManager.OnFinishGame += OnFinishGame;
        _gameManager.OnStartGame += OnStartGame;
        _gameManager.OnRestartGame += OnRestartGame;
    }

    private void OnDisable()
    {
        _player.Died -= PlayerOnDied;
        _gameManager.OnFinishGame -= OnFinishGame;
        _gameManager.OnStartGame -= OnStartGame;
        _gameManager.OnRestartGame -= OnRestartGame;
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

    private void OnFinishGame()
    {
        ShowWindow(WindowType.FinishWindow);
    }

    private void OnRestartGame()
    {
        ShowWindow(WindowType.MainWindow);
    }
}