using System;
using Cinemachine;
using Obstacle;
using Type;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public event Action OnRestartGame;
        public event Action OnFinishGame;
        public event Action OnStartGame;

        [SerializeField] private CinemachineVirtualCamera _mainCamera;
        [SerializeField] private CinemachineVirtualCamera _failCamera;
        [SerializeField] private CinemachineVirtualCamera _finishCamera;

        private Player.Player _player;
        private AudioManager _audioManager;
        [SerializeField] private ObstacleController _obstacleController;

        private bool _isGameStarted = false;
        private bool _isGameFinished = false;

        public bool IsGameStarted => _isGameStarted;
        public bool IsGameFinished => _isGameFinished;

        [Inject]
        private void Construct(Player.Player player, AudioManager audioManager)
        {
            _player = player;
            _audioManager = audioManager;
            _player.OnPlayerDied += PlayerOnOnPlayerDied;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !_isGameStarted && !_isGameFinished)
            {
                StartGame();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _player.Die();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                FinishGame();
            }
        }

        public void StartGame()
        {
            _isGameStarted = true;
            OnStartGame?.Invoke();
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
            OnFinishGame?.Invoke();
            _mainCamera.Priority = 0;
            _failCamera.Priority = 0;
            _finishCamera.Priority = 10;
            _player.RotatePlayer(_finishCamera.transform);
        }

        private void PlayerOnOnPlayerDied()
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
            _obstacleController.ResetObstacle();
            OnRestartGame?.Invoke();
            StartGame();
        }
    }
}