using System.Collections;
using UnityEngine;

public class GroundMovementLogic : MovementLogic
{
    private float CurrentSpeed => _input.Player.Run.IsPressed() ? _runSpeed : _walkSpeed;

    private readonly float _walkSpeed;
    private readonly float _runSpeed;
    private readonly float _jumpHeight;

    private readonly CharacterController _controller;
    private readonly PlayerInput _input;
    private readonly Transform _transform;

    public GroundMovementLogic(float walkSpeed, float runSpeed, float jumpHeaight,CharacterController controller, PlayerInput input, Transform transform)
    {
        _walkSpeed = walkSpeed;
        _runSpeed = runSpeed;
        _jumpHeight = jumpHeaight;

        _controller = controller;
        _input = input;
        _transform = transform;
    }

    public override void Execute()
    {
        TryMove();
        TryJump();

        MoveDirection += Gravity * Time.deltaTime;
        _controller.Move(MoveDirection * Time.deltaTime);
    }

    private bool TryMove()
    {
        Vector2 direction = _input.Player.Move.ReadValue<Vector2>();

        if (direction == Vector2.zero)
        {
            MoveDirection.x = 0f;
            MoveDirection.z = 0f;

            return false;
        }

        Move(direction);

        return true;
    }

    private bool TryJump()
    {
        if (_input.Player.Jump.IsPressed() == false)
        {
            return false;
        }
        if (_controller.isGrounded == false)
        {
            return false;
        }

        Jump();

        return true;
    }

    private void Jump()
    {
        MoveDirection.y = _jumpHeight;
    }

    private void Move(Vector2 direction)
    {
        Vector3 inputDirection = new Vector3(direction.x, 0f, direction.y);

        inputDirection = _transform.TransformDirection(inputDirection) * CurrentSpeed;

        MoveDirection.x = inputDirection.x;
        MoveDirection.z = inputDirection.z;
    }
}