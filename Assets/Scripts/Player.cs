using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform _targetTransform;
    
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
        _animatorController.Died();
        Debug.Log("Die");
    }

    public void Hit()
    {
        _isDied = false;
        _animatorController.Hit();
        Debug.Log("Hit");
    }
    
    public void ResetPlayerState()
    {
        _isDied = false;
    } 
    
    public void RotatePlayerToTarget()
    { 
        Vector3 direction = _targetTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = targetRotation;
    }
}
