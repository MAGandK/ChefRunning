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
    private PlayerController _playerController;
    private AudioManager _audioManager;
    
    private bool _isGameStarted = false;
    private bool _isGameFinished = false;
    
    private Vector3 _playerPosition;

    public bool IsGameStarted => _isGameStarted;
    public bool IsGameFinished => _isGameFinished;
    private ObstacleBase _obstacleBase;

    [Inject]
    private void Construct(Player player, PlayerController playerController, AudioManager audioManager, ObstacleBase obstacleBase)
    {
       _player = player;
       _playerController = playerController;
       _audioManager = audioManager;
       _obstacleBase = obstacleBase;
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
       _playerController.Dance();
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
        _playerController.Die();
        _audioManager.StopMusic(); 
        _audioManager.PlaySound(SoundType.Fail);
       IsPlayerDie?.Invoke();
       _mainCamera.Priority = 0;  
       _failCamera.Priority = 10;
    }

    public void PlayerHit()
    {
        _playerController.Hit();
        _audioManager.PlaySound(SoundType.Push);
        IsPlayerHit?.Invoke();
    }

    public void RestartGame()
    {
        _isGameFinished = false;
        ResetPlayerPosition();
        _player.ResetPlayerState();
        _playerController.ResetState();
        IsRestartGame?.Invoke(); 
        //_obstacleBase.ResetObstacle();
        StartGame();
    }
    public void ResetPlayerPosition()
    {
        _player.transform.position = _playerPosition; 
    }
}
