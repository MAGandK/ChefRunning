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
    private CameraController _cameraController;
    
    
    private bool _isGameStarted = false;
    private bool _isGameFinished = false;
    
    private Vector3 _playerPosition;

    public bool IsGameStarted => _isGameStarted;
    public bool IsGameFinished => _isGameFinished;

    [Inject]
    private void Construct( Player player, CameraController cameraController)
    {
        _player = player;
        _cameraController = cameraController;
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
        if (_isGameStarted) return;
    
        _isGameStarted = true;
        Debug.Log("Игра начата"); 
        IsStartGame?.Invoke();
        _cameraController.SetPlayer(_player.transform);
        _playerPosition = _player.transform.position;
    }

    public void FinishGame()
    {
        if (_isGameFinished) return;
        _isGameFinished = true;
        _player.Dansing();
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
        _isGameStarted = true;
        _isGameFinished = false;

       _player.ResetPlayerState();
       ResetPlayerPosition();
 
       IsRestartGame?.Invoke();
       
       StartGame();
       Debug.Log("Продолжаем играть после рестарта"); 
    }
    
    private void ResetPlayerPosition()
    {
        if (_player != null)
        {
            _player.transform.position = _playerPosition; 
            Debug.Log("Позиция игрока сброшена на стартовую: " + _playerPosition);
        }
    }
}
