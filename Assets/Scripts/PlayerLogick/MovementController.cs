using System;
using UI;
using UnityEngine;
using Zenject;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _forwardSpeed = 0f;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField, Range(0f, 1f)] private float _swipeSensitivity;
    [SerializeField] private float _xMaxClamp = 5f;
    [SerializeField] private float _xMinClamp = -11f;

    private Player _player;
    private GameManager _gameManager;
    private Joystick _joystick;

    private float _moveX;
    private float _moveZ;

    private Vector2 _joystickStartPosition;
    private Vector3 _startTransformPosition;

    [Inject]
    private void Construct(Player player,
        GameManager gameManager,
        AnimatorController animatorController,
        Joystick joystick)
    {
        _joystick = joystick;
        _player = player;
        _gameManager = gameManager;
    }

    private void Awake()
    {
        _joystick.PointerUp += JoystickOnPointerUp;
        _joystick.PointerDown += JoystickOnPointerDown;
    }

    private void OnDestroy()
    {
        _joystick.PointerUp -= JoystickOnPointerUp;
        _joystick.PointerDown -= JoystickOnPointerDown;
    }

    private void JoystickOnPointerDown()
    {
        _joystickStartPosition = _joystick.Position;
        _startTransformPosition = transform.position;
    }

    private void JoystickOnPointerUp()
    {
        _joystickStartPosition = _joystick.Position;
        _startTransformPosition = transform.position;
    }

    private void Update()
    {
        if (!_gameManager.IsGameStarted || _player.IsDead || _gameManager.IsGameFinished)
        {
            StopPlayerMovement();
            return;
        }

        //MovePlayer();
        NewMovePlayer();
    }

    public void MovePlayer()
    {
        Debug.Log(_joystickStartPosition.x - _joystick.Position.x);

        var position = transform.position;
        Vector2 joystickInput = _joystick.Direction;

        var expectedMoveX = position.x + (joystickInput.x * _swipeSensitivity) * (_speed * Time.deltaTime);
        _moveX = Mathf.Clamp(expectedMoveX, _xMinClamp, _xMaxClamp);

        _moveZ = position.z + _forwardSpeed * Time.deltaTime;

        Vector3 newPosition = new Vector3(_moveX, position.y, _moveZ);
        _rigidbody.MovePosition(newPosition);

        _player.PlayerMove();
    }


    private void NewMovePlayer()
    {
        var position = transform.position;

        var moveZ = position.z + _forwardSpeed * Time.deltaTime;

        var deltaX = _joystick.Position.x - _joystickStartPosition.x;
        var expectedX = _startTransformPosition.x + deltaX * _swipeSensitivity;

        var clampedX = Mathf.Clamp(expectedX, _xMinClamp, _xMaxClamp);

        //var moveX = Mathf.LerpUnclamped(position.x, clampedX, _smoothingFactor * Time.deltaTime);

        Vector3 newPosition = new Vector3(clampedX, position.y, moveZ);

        _rigidbody.MovePosition(newPosition);
    }


    public void StopPlayerMovement()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        var from = transform.position;
        from.x = _xMinClamp;
        var to = from;
        to.y += 10;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(from, to);
        from.x = _xMaxClamp;
        
        to = from;
        to.y += 10;
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(from, to);
    }
}