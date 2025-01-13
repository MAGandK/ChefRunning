using UnityEngine;
using Zenject;
public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _forwardSpeed = 0f; 
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField, Range(0f,1f)] private float _swipeSensitivity;
    
    private Player _player;
    private GameManager _gameManager;
    private Joystick _joystick;
  
    private float _moveX; 
    private float _moveZ;
    private float _xMaxClamp = 5f;
    private float _xMinClamp = -11f;
  
    [Inject]
    private void Construct(Player player, GameManager gameManager,Joystick joystick)
    {
        _player = player;
        _gameManager = gameManager;
        _joystick = joystick;
    }

    private void Update()
    {    
        if (!_gameManager.IsGameStarted ||_player.PlayerStateController.IsDead|| _gameManager.IsGameFinished)
        {
            StopPlayerMovement();
            return;
            
        }
        MovePlayer();
    }

    public void MovePlayer()
    {
        var position = transform.position;
        Vector2 joystickInput = _joystick.Direction;
        var expectedMoveX = position.x + (joystickInput.x * _swipeSensitivity) * (_speed * Time.deltaTime);
        _moveX = Mathf.Clamp(expectedMoveX, _xMinClamp, _xMaxClamp);
        _moveZ = position.z + (+_forwardSpeed * Time.deltaTime);
        Vector3 newPosition = new Vector3(_moveX, position.y, _moveZ);
        _rigidbody.MovePosition(newPosition);
        _player.PlayerMove();
    }
    
    public void StopPlayerMovement()
    {
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero; 
    }
}