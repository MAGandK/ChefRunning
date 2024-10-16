using System;
using Cinemachine;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _mainCamera;
    [SerializeField] private CinemachineVirtualCamera _failCamera;
    [SerializeField] private CinemachineVirtualCamera _finishCamera;
    [SerializeField] private GameObject _uiFinish;
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
        _audioManager.PlaySound(SoundType.Game);
        _mainCamera.Priority = 10;  
        _failCamera.Priority = 0;
        _finishCamera.Priority = 0;
    }

    public void FinishGame()
    {
        _isGameFinished = true;
        _player.Dance();
        IsFinishGame?.Invoke();
        _audioManager.StopMusic();
        _audioManager.PlaySound(SoundType.Finish);
        _mainCamera.Priority = 0;  
        _failCamera.Priority = 0;
        _finishCamera.Priority = 10;
        _uiFinish.layer = LayerMask.NameToLayer("UIBack");
    }

    public void PlayerDied()
    {
        _player.Die();
       IsPlayerDie?.Invoke();
       _audioManager.StopMusic(); 
       _audioManager.PlaySound(SoundType.Fail);
       _mainCamera.Priority = 0;  
       _failCamera.Priority = 10;
    }

    public void PlayerHit()
    {
        _player.TakeHit();
        IsPlayerHit?.Invoke();
        _audioManager.PlaySound(SoundType.Push);
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
