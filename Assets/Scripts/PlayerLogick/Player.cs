using System;
using Animations;
using PlayerLogick;
using UI;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    public static event Action IsPlayerHit;
    public event Action Died;

    [SerializeField] private Transform _playerModel;
    [SerializeField] private Vector3 _playerPosition;
    [SerializeField] private PlayerAnimationTriggerHelper _playerAnimationTriggerHelper;
    [SerializeField] private ObstacleDestroyer _obstacleDestroyer;

    private AnimatorController _animController;
    private AudioManager _audioManager;
    private Quaternion _startRotation;
    private Joystick _joystick;
    
    public bool IsDead { get; private set; }

    [Inject]
    public void Construct(AnimatorController animatorController,
        AudioManager audioManager,
        Joystick joystick)
    {
        _joystick = joystick;
        _animController = animatorController;
        _audioManager = audioManager;
    }

    private void Awake()
    {
        _playerAnimationTriggerHelper.PunchStarted += OnPunchStarted;
        _playerAnimationTriggerHelper.PunchEnded += OnPunchEnded;
        _joystick.DoubleClick += JoystickOnDoubleClick;
    }

    private void OnEnable()
    {
        //PlayerAnimationTriggerHelper.AnimationEndHandler += AnimHitEnd;
    }

    private void Start()
    {
        _startRotation = _playerModel.rotation;
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
        IsDead = false;
        transform.position = _playerPosition;
        _playerModel.rotation = _startRotation;
        _animController.ResetAnimation();
    }

    private void OnPunchEnded()
    {
        _obstacleDestroyer.SetCanDestroy(false);
    }

    private void OnPunchStarted()
    {
        _obstacleDestroyer.SetCanDestroy(true);
    }

    private void JoystickOnDoubleClick()
    {
        PlayerHit();
    }

    public void Die()
    {
        IsDead = true;
        _animController.Dying();
        Died?.Invoke();
    }
}