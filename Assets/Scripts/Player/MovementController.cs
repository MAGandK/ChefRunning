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
    private DynamicJoystick _dynamicJoystick;
  
    private float _moveX; 
    private float _moveZ;
    private float _xMaxClamp = 5f;
    private float _xMinClamp = -11f;
  
    [Inject]
    private void Construct(Player player, GameManager gameManager,DynamicJoystick dynamicJoystick, AnimatorController animatorController)
    {
        _player = player;
        _gameManager = gameManager;
        _dynamicJoystick = dynamicJoystick;
    }

    private void Update()
    {    
        if (!_gameManager.IsGameStarted ||_player.IsDead|| _gameManager.IsGameFinished || _player._isPlayerHit)
        {
            StopPlayerMovement();
            return;
            
        }
        MovePlayer();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
           HitButtonPush();
        }
    }

    public void MovePlayer()
    {
        var position = transform.position;
        Vector2 joystickInput = _dynamicJoystick.Direction;
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

    public void HitButtonPush()
    {
        _player.PlayerHit(true);
        StopPlayerMovement();
    }
}