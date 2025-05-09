using Managers;
using PlayerLogics;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera _mainCamera;
        [SerializeField] private CinemachineCamera _failCamera;
        [SerializeField] private CinemachineCamera _finishCamera;
    
        private GameManager _gameManager;
        private Player _player;

        public Vector3 FinishCameraPosition => _finishCamera.transform.position;
    
        [Inject]
        private void Construct(GameManager gameManager, Player player)
        {
            _gameManager = gameManager;
            _player = player;
        }
        private void OnEnable()
        {
            _gameManager.GameStarted += GameManagerOnGameStarted;
            _gameManager.GameFinished += GameManagerOnGameFinished;
            _gameManager.GameExited += GameManagerOnGameExited;
            _player.Died += PlayerOnDied;
        }
    
        private void OnDisable()
        {
            _gameManager.GameStarted -= GameManagerOnGameStarted;
            _gameManager.GameFinished -= GameManagerOnGameFinished;
            _gameManager.GameExited -= GameManagerOnGameExited;
        }

        private void GameManagerOnGameStarted()
        {
            _mainCamera.Priority = 10;
            _failCamera.Priority = 0;
            _finishCamera.Priority = 0;
        }

        private void GameManagerOnGameFinished()
        {
            _mainCamera.Priority = 0;
            _failCamera.Priority = 0;
            _finishCamera.Priority = 10;
        }
    
        private void PlayerOnDied()
        {
            _mainCamera.Priority = 0;
            _failCamera.Priority = 10;
        }
    
        private void GameManagerOnGameExited()
        {
            _mainCamera.Priority = 10;
            _failCamera.Priority = 0;
            _finishCamera.Priority = 0;
        }
    }
}