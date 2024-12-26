using System;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    public static event Action IsPlayerHit;

    [SerializeField] private Transform _playerModel;
    [SerializeField] private Vector3 _playerPosition;

    private AnimatorController _animController;
    private AudioManager _audioManager;
    private Quaternion _startRotation;
    private bool _isDead = false;
    internal bool _isPlayerHit;
    public bool IsDead => _isDead;

    [Inject]
    public void Construct(AnimatorController animatorController, AudioManager audioManager)
    {
        _animController = animatorController;
        _audioManager = audioManager;
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

    public void ResetPlayerState()
    {
        _playerModel.rotation = _startRotation;
    }

    public void Die()
    {
        _isDead = true;
        _animController.Dying();
    }

    public void Dance()
    {
        _animController.Danced();
    }

    public void ResetState()
    {
        _isDead = false;
        _animController.ResetAnimation();
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

    public void ResetPlayerPosition()
    {
        transform.position = _playerPosition;
    }

    private void AnimHitEnd()
    {
        _isPlayerHit = false;
    }

    private void OnDisable()
    {
        AnimationTrigger.AnimationEndHandler -= AnimHitEnd;
    }
}