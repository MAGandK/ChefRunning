using System;
using Animations;
using Managers;
using Obstacle;
using Type;
using UnityEngine;
using Zenject;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public event Action OnPlayerHit;
        public event Action OnPlayerDied;

        [SerializeField] private Transform _playerModel;
        [SerializeField] private Vector3 _playerPosition;
        [SerializeField] private PlayerAnimationTriggetHelper _playerAnimationTriggetHelper;
        [SerializeField] private ObstacleDestroyer _obstacleDestroyer;
        [SerializeField] private MovementController _movementController;

        private AnimatorController _animController;
        private AudioManager _audioManager;
        private GameManager _gameManager;
        private Joystick.Joystick _joystick;
        private Quaternion _startRotation;

        private bool _isDead = false;
        public bool IsDead => _isDead;

        [Inject]
        public void Construct(AnimatorController animatorController, AudioManager audioManager, GameManager gameManager,
            Joystick.Joystick joystick)
        {
            _animController = animatorController;
            _audioManager = audioManager;
            _gameManager = gameManager;
            _joystick = joystick;
        }

        private void Awake()
        {
            _playerAnimationTriggetHelper.PunchStarted += OnPunchStarted;
            _playerAnimationTriggetHelper.PunchEnded += OnPunchEnded;
            _joystick.DoubleClick += OnDoubleClick;
            _gameManager.OnStartGame += GameManagerOnStartGame;
        }

        private void GameManagerOnStartGame()
        {
            _movementController.StartMove();
        }

        private void OnDoubleClick()
        {
            PlayerHit();
        }

        private void OnPunchEnded()
        {
            _obstacleDestroyer.SetCanDestroy(false);
        }

        private void OnPunchStarted()
        {
            _obstacleDestroyer.SetCanDestroy(true);
        }

        private void Start()
        {
            _startRotation = _playerModel.rotation;
        }

        public void Die()
        {
            _isDead = true;
            _animController.Dying();
            _movementController.StopPlayerMovement();
            OnPlayerDied?.Invoke();
        }

        public void RotatePlayer(Transform targetTransform)
        {
            var direction = (targetTransform.position - _playerModel.position).normalized;
            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _playerModel.rotation = targetRotation;
        }

        public void Dance()
        {
            _animController.Danced();
        }

        public void PlayerHit()
        {
            _animController.Hitting();
            _audioManager.PlaySound(SoundType.Push);
            OnPlayerHit?.Invoke();
        }

        public void Reset()
        {
            transform.position = _playerPosition;
            _animController.ResetAnimation();
            _playerModel.rotation = _startRotation;
            _isDead = false;
        }
    }
}