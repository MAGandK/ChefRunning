using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _playerModel;
    private Quaternion _startRotation;

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
}
