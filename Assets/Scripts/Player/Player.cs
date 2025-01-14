using System;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    public static event Action IsPlayerHit;
    public event Action Died;

    [SerializeField] private Transform _playerModel;
    [SerializeField] private Vector3 _playerPosition;
    [SerializeField] private PlayerAnimationTriggetHelper _playerAnimationTriggetHelper;
    [SerializeField] private ObstacleDestroyer _obstacleDestroyer;

    private AnimatorController _animController;
    private AudioManager _audioManager;
    private Joystick _joystick;
    private Quaternion _startRotation;

    private bool _isDead = false;
    public bool IsDead => _isDead;

    [Inject]
    public void Construct(AnimatorController animatorController, AudioManager audioManager, Joystick joystick)
    {
        _animController = animatorController;
        _audioManager = audioManager;
        _joystick = joystick;
    }

    private void Awake()
    {
        _playerAnimationTriggetHelper.PunchStarted += OnPunchStarted;
        _playerAnimationTriggetHelper.PunchEnded += OnPunchEnded;
        _joystick.DoubleClick += OnDoubleClick;
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
        _animController.Dying();
        _isDead = true;
        Died?.Invoke();
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

    public void PlayerMove()
    {
        _animController.Running();
    }

    public void PlayerHit()
    {
        _animController.Hitting();
        _audioManager.PlaySound(SoundType.Push);
        IsPlayerHit?.Invoke();
    }

    public void Reset()
    {
        transform.position = _playerPosition;
        _animController.ResetAnimation();
        _playerModel.rotation = _startRotation;
        _isDead = false;
    }

    // private void OnDisable()
    // {
    //     _playerStateController.Died -= PlayerStateControllerOnDied;
    //     _playerAnimationTriggetHelper.PunchStarted -= OnPunchStarted;
    //     _playerAnimationTriggetHelper.PunchEnded -= OnPunchEnded ;
    // }
}