using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    public static event Action IsRestartGame;
    public static event Action IsFinishGame;
    public static event Action IsStartGame;

    [SerializeField] private CinemachineVirtualCamera _mainCamera;
    [SerializeField] private CinemachineVirtualCamera _failCamera;
    [SerializeField] private CinemachineVirtualCamera _finishCamera;

    private Player _player;
    private AudioManager _audioManager;

    private bool _isGameStarted = false;
    private bool _isGameFinished = false;

    public bool IsGameStarted => _isGameStarted;
    public bool IsGameFinished => _isGameFinished;

    private List<GameObject> _obstacle = new List<GameObject>();

    [SerializeField] private GameObject[] _explosionEffects;

    [Inject]
    private void Construct(Player player, AudioManager audioManager)
    {
        _player = player;
        _audioManager = audioManager;
        _player.PlayerStateController.Died += PlayerOnDied;
    }

    private void OnEnable()
    {
      //  ObstacleHammer.HammerFall += ObstacleHammerFall;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isGameStarted && !_isGameFinished)
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _player.PlayerStateController.Die();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            TestFinishGame();
        }
    }
    

    /// <summary>
    /// Test method function
    /// </summary>
    public void TestFinishGame()
    {
        FinishGame();
    }

    public void StartGame()
    {
        _isGameStarted = true;
        IsStartGame?.Invoke();
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

    private void PlayerOnDied()
    {
        _audioManager.StopMusic();
        _audioManager.PlaySound(SoundType.Fail);
        
        
        _mainCamera.Priority = 0;
        _failCamera.Priority = 10;
    }
 

    public void RestartGame()
    {
        _isGameFinished = false;
        
        _player.Reset();
        IsRestartGame?.Invoke();
        StartGame();
    }

    public void ObstacleCollision(GameObject obstacle)
    {
        // if (_player._isPlayerHit)
        // {
        //     HitObstacle(obstacle);
        // }
        // else
        // {
        //     foreach (var item in _obstacle)
        //     {
        //         item.SetActive(true);
        //     }
        //
        //     _obstacle.Clear();
        //     obstacle.GetComponent<ObstacleBarrel>().StopAllCoroutines();
        //
        // }
    }

    private void HitObstacle(GameObject obj)
    {
        _obstacle.Add(obj);
        ActivateHitEffects(obj.transform);
        obj.GetComponent<ObstacleBarrel>().StopAllCoroutines();
        obj.SetActive(false);
    }
    

    public void ActivateHitEffects(Transform obstacleTransform)
    {
        foreach (var effect in _explosionEffects)
        {
            Instantiate(effect, obstacleTransform.position, Quaternion.identity);
        }
    }

    private void OnDisable()
    {
        //ObstacleHammer.HammerFall -= ObstacleHammerFall;
    }
}