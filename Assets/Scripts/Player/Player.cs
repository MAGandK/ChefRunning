using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    private AnimatorController _animatorController;
    private bool _isDead = false;
    private bool _isHitting = false;
    [SerializeField]
    private Transform _playerModel;
    private Quaternion _startRotation;
    
    [Inject]
    private void Construct(AnimatorController animatorController)
    {
        _animatorController = animatorController;
    }

    private void Start()
    {
        _startRotation = _playerModel.rotation;
    }
    public bool IsDead
    {
        get => _isDead;
    }

    public bool IsHitting
    {
        get => _isHitting;
    }
    
    public void Die()
    {
        _isDead = true;
        _animatorController.Dying();
    }

    public void Hit()
    {
        _isHitting = true;
        _animatorController.Hitting();
    }

    public void Dance()
    {
        _animatorController.Danced();
    }
    
    public void RotatePlayer(Transform targetTransform)
    {
        var direction = (targetTransform.position - _playerModel.position).normalized;
        direction.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        _playerModel.rotation = targetRotation;
    }
    public void ResetState()
    {
        _isDead = false;
        _animatorController.ResetAnimation();
        _playerModel.rotation = _startRotation;
    }
}
