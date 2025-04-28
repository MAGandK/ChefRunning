using Audio;
using Audio.Types;
using Camera;
using JoystickControls;
using LevelLogic;
using Obstacle;
using UI;
using UI.UIController;
using UI.WinodwsLogic.Window.FailWindow;
using UnityEngine;
using Zenject;

namespace PlayerLogics
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform _playerModel;
        [SerializeField] private Vector3 _playerPosition;
        [SerializeField] private PlayerAnimationTriggetHelper _playerAnimationTriggetHelper;
        [SerializeField] private ObstacleDestroyer _obstacleDestroyer;
        [SerializeField] private PlayerMovementController _playerMovementController;
        [SerializeField] private PlayerAnimatorController _animatorController;
        [SerializeField] private Collider[] _hitColliders;

        private IJoystickController _joystick;
        private CameraController _cameraController;
        private IUIController _uiController;
        private IAudioManager _audioManager;
        private ILevelModel _levelModel;

        [Inject]
        public void Construct(
            IJoystickController joystick,
            CameraController cameraController,
            IUIController uiController,
            IAudioManager audioManager,
            ILevelModel levelModel)
        {
            _levelModel = levelModel;
            _audioManager = audioManager;
            _joystick = joystick;
            _cameraController = cameraController;
            _uiController = uiController;
        }

        private void Awake()
        {
            _playerAnimationTriggetHelper.PunchStarted += OnPunchStarted;
            _playerAnimationTriggetHelper.PunchEnded += OnPunchEnded;
            _joystick.DoubleClick += DoubleClick;

            _levelModel.StateChanged += LevelModelOnStateChanged;
        }

        private void OnDestroy()
        {
            _playerAnimationTriggetHelper.PunchStarted -= OnPunchStarted;
            _playerAnimationTriggetHelper.PunchEnded -= OnPunchEnded;
            _joystick.DoubleClick -= DoubleClick;

            _levelModel.StateChanged -= LevelModelOnStateChanged;
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
        }

        public void Die()
        {
            _audioManager.Play(SoundType.Damaged);
            _animatorController.Dying();
            _playerMovementController.StopMovement();

            foreach (var hitCollider in _hitColliders)
            {
                hitCollider.enabled = false;
            }

            _levelModel.SetState(LevelState.Fail);
            _uiController.ShowWindow<FailWindowController>();
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

        private void OnLevelStarted()
        {
            _playerMovementController.StartMove();
            _animatorController.Running();
        }

        private void OnLevelFinished()
        {
            _playerMovementController.StopMovement();
            RotatePlayer(_cameraController.FailViewTransform);
            Dance();
        }

        private void LevelModelOnStateChanged(LevelState levelState)
        {
            switch (levelState)
            {
                case LevelState.Start:
                    OnLevelStarted();
                    break;
                case LevelState.Win:
                    OnLevelFinished();
                    break;
            }
        }
    }
}