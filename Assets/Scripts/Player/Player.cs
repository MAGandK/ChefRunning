using System;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    public static event Action IsPlayerHit;

    [SerializeField] private Transform _playerModel;
    [SerializeField] private Vector3 _playerPosition;
    [SerializeField] private PlayerLifeController _playerLifeController;

    private AnimatorController _animController;
    private AudioManager _audioManager;
    private Quaternion _startRotation;
    internal bool _isPlayerHit;

    public PlayerLifeController PlayerLifeController => _playerLifeController;

    [Inject]
    public void Construct(AnimatorController animatorController, AudioManager audioManager)
    {
        _animController = animatorController;
        _audioManager = audioManager;
    }

    private void Awake()
    {
        _playerLifeController.Died += PlayerLifeControllerOnDied;
    }

    private void PlayerLifeControllerOnDied()
    {
        _animController.Dying();
    }

    private void OnEnable()
    {
        AnimationTrigger.AnimationEndHandler += AnimHitEnd;
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
        _isPlayerHit = false;
    }

    public void PlayerHit(bool _isPress)
    {
        _isPlayerHit = _isPress;
        _animController.Hitting();
        _audioManager.PlaySound(SoundType.Push);
        IsPlayerHit?.Invoke();
    }
    
    private void AnimHitEnd()
    {
        _isPlayerHit = false;
    }

    private void OnDisable()
    {
        AnimationTrigger.AnimationEndHandler -= AnimHitEnd;
    }

    public void Reset()
    {
        transform.position = _playerPosition;
        _playerModel.rotation = _startRotation;
        _animController.ResetAnimation();
        _playerLifeController.Restart();
    }
}