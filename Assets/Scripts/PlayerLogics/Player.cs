using System;
using JoystickControls;
using Managers;
using Obstacle;
using Type;
using UI;
using UI.Window;
using UnityEngine;
using Zenject;

namespace PlayerLogics
{
    public class Player : MonoBehaviour
    {
        public event Action Hited;
        public event Action Died;

        [SerializeField] private Transform _playerModel;
        [SerializeField] private Vector3 _playerPosition;
        [SerializeField] private PlayerAnimationTriggetHelper _playerAnimationTriggetHelper;
        [SerializeField] private ObstacleDestroyer _obstacleDestroyer;
        [SerializeField] private MovementController _movementController;
        [SerializeField] private PlayerAnimatorController _animatorController;

        private AudioManager _audioManager;
        private GameManager _gameManager;
        private Joystick _joystick;
        private CameraController _cameraController;
        private UIController _uiController;
        private Quaternion _startRotation;

        [Inject]
        public void Construct
        (AudioManager audioManager, 
            GameManager gameManager,
            Joystick joystick, 
            CameraController cameraController, 
            UIController uiController)
        {
            _audioManager = audioManager;
            _gameManager = gameManager;
            _joystick = joystick;
            _cameraController = cameraController;
            _uiController = uiController;
        }

        private void Awake()
        {
            _playerAnimationTriggetHelper.PunchStarted += OnPunchStarted;
            _playerAnimationTriggetHelper.PunchEnded += OnPunchEnded;
            _joystick.DoubleClick += DoubleClick;
            _gameManager.GameStarted += GameManagerGameStarted;
            _gameManager.GameFinished += GameManagerOnGameFinished;
            _gameManager.GameRestarted += GameManagerOnGameRestarted;
        }

        private void OnDestroy()
        {
            _playerAnimationTriggetHelper.PunchStarted -= OnPunchStarted;
            _playerAnimationTriggetHelper.PunchEnded -= OnPunchEnded;
            _joystick.DoubleClick -= DoubleClick;
            _gameManager.GameStarted -= GameManagerGameStarted;
            _gameManager.GameFinished -= GameManagerOnGameFinished;
            _gameManager.GameRestarted -= GameManagerOnGameRestarted;
        }
        
        private void Start()
        {
            _startRotation = _playerModel.rotation;
        }
        
        private void RotatePlayer(Vector3 targetPosition)
        {
            var direction = (targetPosition - _playerModel.position).normalized;
            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _playerModel.rotation = targetRotation;
        }

        private void Dance()
        {
            _animatorController.Danced();
        }

        private void Hit()
        {
            _animatorController.Hitting();
            _audioManager.PlaySound(SoundType.Push);
            Hited?.Invoke();
        }
        
        public void Die()
        {
            _animatorController.Dying();
            _movementController.StopMovement();

            _audioManager.StopMusic();
            _audioManager.PlaySound(SoundType.Fail);
            _uiController.ShowWindow<FailWindow>();

            Died?.Invoke();
        }

        private void DoubleClick()
        {
            Hit();
        }

        private void OnPunchEnded()
        {
            _obstacleDestroyer.SetCanDestroy(false);
        }

        private void OnPunchStarted()
        {
            _obstacleDestroyer.SetCanDestroy(true);
        }
        private void GameManagerGameStarted()
        {
            _movementController.StartMove();
            _animatorController.Running();
        }

        private void GameManagerOnGameRestarted()
        {
            transform.position = Vector3.zero;
            _playerModel.rotation = _startRotation;
            _movementController.Reset();
            _animatorController.ResetAnimation();
        }

        private void GameManagerOnGameFinished()
        {
            _movementController.StopMovement();
            RotatePlayer(_cameraController.FinishCameraPosition);
            Dance();
        }
    }
}