using UnityEngine;
using Zenject;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _forwardSpeed = 0f; 
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField, Range(0f,1f)] private float _swipeSensitivity;
    
    private Player _player;
    private GameManager _gameManager;
    private DynamicJoystick _dynamicJoystick;
    private AnimatorController _animatorController;
    
    private float _moveX; 
    private float _moveZ;
    private float _xMaxClamp = 5f;
    private float _xMinClamp = -11f;
    
    private bool _isDead = false;
    private bool _isHitting = false;
    private bool _isHitPressed = false;
    public bool IsHitPressed => _isHitPressed;
    public bool IsDead => _isDead;
    public bool IsHitting => _isHitting;
    
    
    [Inject]
    private void Construct(Player player, GameManager gameManager,DynamicJoystick dynamicJoystick, AnimatorController animatorController)
    {
        _player = player;
        _gameManager = gameManager;
        _animatorController = animatorController;
        _dynamicJoystick = dynamicJoystick;
    }

    private void Update()
    {    
        if (!_gameManager.IsGameStarted ||IsDead|| _gameManager.IsGameFinished)
        {
            StopPlayerMovement();
            return;
            
        }
        MovePlayer();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isHitPressed = true;
            StopPlayerMovement();
            OnHitButtonPressed();
        }
        
        if (_animatorController._animator.GetBool("IsRun"))
        {
            MovePlayer();
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
    }
    
    public void StopPlayerMovement()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero; 
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
    
    public void ResetState()
    {
        _isDead = false;
        _player.ResetPlayerState();
        _animatorController.ResetAnimation();
    }
    public void OnHitButtonPressed()
    {
        Debug.Log("удар по кнопке");
        _gameManager.PlayerHit();
        _isHitPressed = true; 
    }
   
    public void ResetHitPressed()
    {
        _isHitPressed = false;
    }
}