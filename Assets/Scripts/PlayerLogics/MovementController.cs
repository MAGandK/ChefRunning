using JoystickControls;
using UnityEngine;
using Zenject;

namespace PlayerLogics
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField, Range(0f, 1f)] private float _swipeSensitivity;
        [SerializeField] private float _forwardSpeed = 0f;
        [SerializeField] private float _xMaxClamp = 5f;
        [SerializeField] private float _xMinClamp = -11f;
        
        [SerializeField] private Rigidbody _rigidbody;
        private Joystick _joystick;

        private bool _canMove;
        private Vector2 _joystickStartPosition;
        private Vector3 _startTransformPosition;
        
        [Inject]
        private void Construct(Joystick joystick)
        {
            _joystick = joystick;
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

        private void Update()
        {
            if (_canMove)
            {
                MovePlayer();
            }
        }

        public void StartMove()
        {
            _canMove = true;
        }
        
        private void MovePlayer()
        {
            var position = transform.position;
            var moveZ = position.z + _forwardSpeed * Time.deltaTime;
            var deltaX = _joystick.Position.x - _joystickStartPosition.x;
            var expectedX = _startTransformPosition.x + deltaX * _swipeSensitivity;
            var clampedX = Mathf.Clamp(expectedX, _xMinClamp, _xMaxClamp);
            Vector3 newPosition = new Vector3(clampedX, position.y, moveZ);

            _rigidbody.MovePosition(newPosition);
        }
 
        public void StopMovement()
        {
            _canMove = false;
            _rigidbody.linearVelocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
        
        public void Reset()
        {
            _canMove = false;
            _startTransformPosition = transform.position;
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
    }
}