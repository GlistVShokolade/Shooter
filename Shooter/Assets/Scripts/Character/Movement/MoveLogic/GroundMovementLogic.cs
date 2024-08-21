using UnityEngine;

public class GroundMovementLogic : MovementLogic
{
    private float _currentSpeed;

    private readonly Transform _transform;

    private readonly float _moveSpeed;
    private readonly float _runSpeed;
    private readonly float _jumpForce;

    private readonly Vector3 _gravity = new Vector3(0f, -9.81f, 0f);

    public GroundMovementLogic(float moveSpeed, float runSpeed, float jumpForce, Transform transform, CharacterController controller) : base(controller)
    {
        _moveSpeed = moveSpeed;
        _runSpeed = runSpeed;
        _jumpForce = jumpForce;

        _transform = transform;
    }

    public override void Update()
    {
        _currentSpeed = GetCurrentSpeed();

        TryMove();
        TryJump();

        ApplyGravity();

        _controller.Move(_moveDirection * Time.deltaTime);
    }

    private float GetCurrentSpeed()
    {
        return Input.Movement.Run.IsPressed() ? _runSpeed : _jumpForce;
    }

    private bool TrySquat()
    {
        return true;
    }

    private bool TryJump()
    {
        if (_controller.isGrounded == false)
        {
            return false;
        }
        if (Input.Movement.Jump.IsPressed() == false)
        {
            return false;
        }

        Jump();

        return true;
    }

    private bool TryMove()
    {
        Vector2 inputDirection = Input.Movement.Move.ReadValue<Vector2>();

        if (inputDirection == Vector2.zero)
        {
            SetDirection(0f, _moveDirection.y, 0f);

            return false;
        }

        Move(inputDirection);

        return true;
    }

    private void Move(Vector2 direction)
    {
        Vector3 inputDirection = new Vector3(direction.x, 0f, direction.y);

        inputDirection = _transform.TransformDirection(inputDirection) * _currentSpeed;

        SetDirection(inputDirection.x, _moveDirection.y, inputDirection.z);
    }

    private void Jump()
    {
        SetDirection(_moveDirection.x, _jumpForce, _moveDirection.z);
    }

    private void ApplyGravity()
    {
        _moveDirection += _gravity * Time.deltaTime;
    }
}