using UnityEngine;
using UnityEngine.InputSystem;

public enum MoveDirection
{
    Up,
    Down,
    Left,
    Right
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private float _rotationSpeed = 360f;

    // 👇 NEW: how much to rotate so the sprite "forward" matches movement
    [SerializeField]
    private float _rotationOffset = 0f;

    private Rigidbody2D _rigidbody;

    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    private bool _moveUp;
    private bool _moveDown;
    private bool _moveLeft;
    private bool _moveRight;

    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        UpdateMovementInputFromButtons();
        SetPlayerVelocity();
        RotateInDirectionOfInput();
    }

    private void UpdateMovementInputFromButtons()
    {
        Vector2 dir = Vector2.zero;

        if (_moveUp) dir.y += 1f;
        if (_moveDown) dir.y -= 1f;
        if (_moveRight) dir.x += 1f;
        if (_moveLeft) dir.x -= 1f;

        _movementInput = dir.normalized;
    }

    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f);

        _rigidbody.linearVelocity = _smoothedMovementInput * _speed;
        // or _rigidbody.velocity if you're using that
    }

    private void RotateInDirectionOfInput()
    {
        if (_smoothedMovementInput.sqrMagnitude > 0.0001f)
        {
            // base angle from movement direction
            float targetAngle = Mathf.Atan2(_smoothedMovementInput.y, _smoothedMovementInput.x) * Mathf.Rad2Deg;

            // 👇 apply sprite-specific offset
            targetAngle += _rotationOffset;

            float newAngle = Mathf.MoveTowardsAngle(
                _rigidbody.rotation,
                targetAngle,
                _rotationSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(newAngle);
        }
    }

    public void SetMove(MoveDirection direction, bool isPressed)
    {
        switch (direction)
        {
            case MoveDirection.Up:
                _moveUp = isPressed;
                break;
            case MoveDirection.Down:
                _moveDown = isPressed;
                break;
            case MoveDirection.Left:
                _moveLeft = isPressed;
                break;
            case MoveDirection.Right:
                _moveRight = isPressed;
                break;
        }
    }
}