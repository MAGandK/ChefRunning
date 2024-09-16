using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _forwardSpeed = 0f; 
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private Joystick _joystick;
    [SerializeField, Range(0f,1f)]
    private float _swipeSensivity;
 
    private AnimatorController _animatorController;
    private GameManager _gameManager;
    
    private float _moveX; 
    private float _moveZ;

    private bool _isDied = false;

    [Inject]
    private void Constract(AnimatorController animatorController, GameManager gameManager)
    {
        _animatorController = animatorController;
        _gameManager = gameManager;

    }

    public bool IsDaed
    {
        get => _isDied;
    }

    private void Update()
    {    
        if (!_gameManager.IsGameStarted || _isDied || _gameManager.IsGameFinished)
        {
            return;
        }
        
        MovePlayer();
    }

    public void MovePlayer()
    {
        var position = transform.position;
        var expectedMoveX = position.x + (_joystick.EventDataDelta.x * _swipeSensivity) * (_speed * Time.deltaTime);
        
        _moveX = Mathf.Clamp(expectedMoveX, -12f, 5.7f);
        _moveZ = position.z + _forwardSpeed * Time.deltaTime;

        Vector3 newPosition = new Vector3(_moveX, position.y, _moveZ);

        _rigidbody.MovePosition(newPosition);
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
}