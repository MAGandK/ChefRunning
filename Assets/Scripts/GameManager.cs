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
    
    private bool _isGameStarted = false;
    private bool _isGameFinished = false;
    
    public bool IsGameStarted => _isGameStarted;
    public bool IsGameFinished => _isGameFinished;

    [Inject]
    private void Construct( Player player)
    {
        _player = player;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isGameStarted)
        {
            StartGame();
        }
    }
    
    public void StartGame()
    {
        _isGameStarted = true;
        IsStartGame?.Invoke();
    }

    public void FinishGame()
    {
        _isGameFinished = true;
        _player.RotatePlayerToTarget();
        IsFinishGame?.Invoke();
    }

    public void PlayerDied()
    {
       _player.Die();
       IsPlayerDie?.Invoke();
    }

    public void RestartGame()
    {
        _isGameStarted = false;
        _isGameFinished = false;

       _player.ResetPlayerState();
       IsRestartGame?.Invoke();
    }
}
