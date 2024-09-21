using System;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    public static event Action IsPlayerDie;
    public static event Action IsRestartGame;
    public static event Action IsFinishGame;
    public static event Action IsStartGame;

    private Player _player;
    private SceneLoader _sceneLoader;
    
    private bool _isGameStarted = false;
    private bool _isGameFinished = false;

    public bool IsGameStarted => _isGameStarted;
    public bool IsGameFinished => _isGameFinished;

    [Inject]
    private void Construct( Player player, SceneLoader sceneLoader)
    {
        _player = player;
        _sceneLoader = sceneLoader;
    }
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isGameStarted && !_isGameFinished)
        {
            StartGame();
        }
    }
    
    public void StartGame()
    {
        _sceneLoader.LoadScene(0);
        if (_isGameStarted) return;
        _isGameStarted = true;
        IsStartGame?.Invoke();
    }

    public void FinishGame()
    {
        if (_isGameFinished) return;
        _isGameFinished = true;
        _player.RotatePlayerToTarget();
        IsFinishGame?.Invoke();
    }

    public void PlayerDied()
    {
        if (_isGameFinished) return;
        _player.Die();
       IsPlayerDie?.Invoke();
    }

    public void RestartGame()
    {
        _isGameStarted = false;
        _isGameFinished = false;

       _player.ResetPlayerState();
       IsRestartGame?.Invoke();
       _sceneLoader.LoadScene(1);
    }
}
