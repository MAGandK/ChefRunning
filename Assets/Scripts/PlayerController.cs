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
    
    [SerializeField, Range(0f,1f)]
    private float _swipeSensivity;
 
    private Player _player;
    private GameManager _gameManager;
    private Joystick _joystick;
    
    private float _moveX; 
    private float _moveZ;
    private float _xMaxClamp = 5f;
    private float _xMinClamp = -11f;


    [Inject]
    private void Construct(Player player, GameManager gameManager, Joystick joystick)
    {
        _player = player;
        _gameManager = gameManager;
        _joystick = joystick;

    }

    private void Update()
    {    
        if (!_gameManager.IsGameStarted || _player.IsDead|| _gameManager.IsGameFinished)
        {
            return;
        }
        
        MovePlayer();
    }

    public void MovePlayer()
    {
            var position = transform.position;
            var expectedMoveX = position.x + (_joystick.EventDataDelta.x * _swipeSensivity) * (_speed * Time.deltaTime);

            _moveX = Mathf.Clamp(expectedMoveX, _xMinClamp, _xMaxClamp);
            _moveZ = position.z + _forwardSpeed * Time.deltaTime;

            Vector3 newPosition = new Vector3(_moveX, position.y, _moveZ);

            _rigidbody.MovePosition(newPosition);
    }
}