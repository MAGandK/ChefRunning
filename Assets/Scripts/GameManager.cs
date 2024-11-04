using System;
using Cinemachine;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _mainCamera;
    [SerializeField] private CinemachineVirtualCamera _failCamera;
    [SerializeField] private CinemachineVirtualCamera _finishCamera;
    public static event Action IsPlayerDie;
    public static event Action IsPlayerHit;
    public static event Action IsRestartGame;
    public static event Action IsFinishGame;
    public static event Action IsStartGame;

    private Player _player;
    private AudioManager _audioManager;
    
    private bool _isGameStarted = false;
    private bool _isGameFinished = false;
    
    private Vector3 _playerPosition;

    public bool IsGameStarted => _isGameStarted;
    public bool IsGameFinished => _isGameFinished;

    [Inject]
    private void Construct( Player player, AudioManager audioManager)
    {
        _player = player;
        _audioManager = audioManager;
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
        _audioManager.PlayBackgroundMusic();
        _mainCamera.Priority = 10;  
        _failCamera.Priority = 0;
        _finishCamera.Priority = 0;
    }

    public void FinishGame()
    {
        _isGameFinished = true;
        _player.Dance();
        _audioManager.StopMusic();
        _audioManager.PlaySound(SoundType.Finish);
        IsFinishGame?.Invoke();
        _mainCamera.Priority = 0;  
        _failCamera.Priority = 0;
        _finishCamera.Priority = 10;
        _player.RotatePlayer(_finishCamera.transform);
    }

    public void PlayerDied()
    {
        _player.Die();
        _audioManager.StopMusic(); 
        _audioManager.PlaySound(SoundType.Fail);
       IsPlayerDie?.Invoke();
       _mainCamera.Priority = 0;  
       _failCamera.Priority = 10;
    }

    public void PlayerHit()
    {
        _player.Hit();
        _audioManager.PlaySound(SoundType.Push);
        IsPlayerHit?.Invoke();
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
