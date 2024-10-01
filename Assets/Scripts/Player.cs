using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    private AnimatorController _animatorController;
    private bool _isDied = false;

    [Inject]
    private void Construct(AnimatorController animatorController)
    {
        _animatorController = animatorController;
    }
    public bool IsDead
    {
        get => _isDied;
    }
    
    public void Die()
    {
        _isDied = true;
        _animatorController.Dying();
        Debug.Log("Die");
    }

    public void Hit()
    {
        _isDied = false;
        _animatorController.Hitting();
        Debug.Log("Hit");
    }
    
    public void ResetPlayerState()
    {
        _isDied = false;
        _animatorController.ResetAnimation();
    } 
    
    public void RotatePlayerToTarget()
    { 
        transform.Rotate(0, 180, 0);
    }

    public void Dansing()
    {
        _animatorController.Danced();
    }
}
