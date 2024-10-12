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
    
    private Vector3 _playerPosition;

    public bool IsGameStarted => _isGameStarted;
    public bool IsGameFinished => _isGameFinished;

    [Inject]
    private void Construct( Player player)
    {
        _player = player;
    }
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isGameStarted && !_isGameFinished)
        {
            StartGame();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            TestDied();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            TestFinishGame();
        }
    }
    
    public void TestDied()
    {
        PlayerDied();
        Debug.Log("Тест: Игрок умер");
    }
    
    public void TestFinishGame()
    {
        FinishGame();
        Debug.Log("Тест: Игра завершена");
    }
    public void StartGame()
    {
        _isGameStarted = true;
        IsStartGame?.Invoke();
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
        _isGameFinished = false;
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
