using System;
using Audio;
using Audio.Types;
using Camera;
using JoystickControls;
using Managers;
using Obstacle;
using UI;
using UI.Window.FailWindow;
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
        [SerializeField] private Collider[] _hitColliders;

        private GameManager _gameManager;
        private IJoystickController _joystick;
        private CameraController _cameraController;
        private IUIController _uiController;
        private Quaternion _startRotation;
        private IAudioManager _audioManager;

        [Inject]
        public void Construct(
            GameManager gameManager,
            IJoystickController joystick,
            CameraController cameraController,
            IUIController uiController,
            IAudioManager audioManager)
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
            _gameManager.GameExited += GameManagerOnGameExited;
        }

        private void OnDestroy()
        {
            _playerAnimationTriggetHelper.PunchStarted -= OnPunchStarted;
            _playerAnimationTriggetHelper.PunchEnded -= OnPunchEnded;
            _joystick.DoubleClick -= DoubleClick;
            _gameManager.GameStarted -= GameManagerGameStarted;
            _gameManager.GameFinished -= GameManagerOnGameFinished;
            _gameManager.GameRestarted -= GameManagerOnGameRestarted;
            _gameManager.GameExited -= GameManagerOnGameExited;
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

            Hited?.Invoke();
        }

        public void Die()
        {
            _audioManager.Play(SoundType.Damaged);
            _animatorController.Dying();
            _movementController.StopMovement();

            foreach (var hitCollider in _hitColliders)
            {
                hitCollider.enabled = false;
            }

            _uiController.ShowWindow<FailWindowController>();
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

        private void GameManagerOnGameExited()
        {
            GameManagerOnGameRestarted();
            _startRotation = _playerModel.rotation;
        }
    }
}