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
        _isGameStarted = true;
        Debug.Log("Игра начата"); 
        IsStartGame?.Invoke();
        _cameraController.SetPlayer(_player.transform);
        _playerPosition = _player.transform.position;
    }

    public void FinishGame()
    {
        _isGameFinished = true;
        _player.Dance();
        IsFinishGame?.Invoke();
    }

    public void PlayerDied()
    {
        _player.Die();
       IsPlayerDie?.Invoke();
    }

    public void RestartGame()
    {
        ResetPlayerPosition();
        _player.ResetState();  
        IsRestartGame?.Invoke();  
        StartGame();
    }
    
    public void ResetPlayerPosition()
    {
        _player.transform.position = _playerPosition; 
    }
}
