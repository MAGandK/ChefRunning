using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    private AnimatorController _animatorController;
    private bool _isDead = false;

    
    [Inject]
    private void Construct(AnimatorController animatorController)
    {
        _animatorController = animatorController;
    }
    public bool IsDead
    {
        get => _isDead;
    }
    
    public void Die()
    {
        _isDead = true;
        _animatorController.Dying();
    }

    public void TakeHit()
    {
        _animatorController.Hitting();
    }
    
    // public void RotatePlayerToTarget()
    // { 
    //     transform.Rotate(0, 180, 0);
    // }

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
