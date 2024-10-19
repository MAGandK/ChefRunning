using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    private AnimatorController _animatorController;
    private bool _isDead = false;
    private bool _isHitting = false;
    
    [Inject]
    private void Construct(AnimatorController animatorController)
    {
        _animatorController = animatorController;
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

    public void TakeHit()
    {
        _isHitting = true;
        _animatorController.Hitting();
    }

    public void Dance()
    {
        _animatorController.Danced();
    }
    
    public void ResetState()
    {
        _isDead = false;
        _animatorController.ResetAnimation();
    }
}
