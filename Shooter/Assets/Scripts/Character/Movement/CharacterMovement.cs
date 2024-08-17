using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private float _currentSpeed;

    private Vector3 _moveDirection;

    private CharacterController _controller;

    [Header("Move")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _runSpeed;
    [Header("Jump")]
    [SerializeField] private float _jumpForce;
    [Header("Gravity")]
    [SerializeField] private Vector3 _gravity = Vector3.down * 9.81f;

    private CharacterInput Input => Character.Instance.Input;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _currentSpeed = GetCurrentSpeed();

        TryMove();
        TryJump();

        ApplyGravity();

        _controller.Move(_moveDirection * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        _moveDirection += _gravity * Time.deltaTime;
    }

    private float GetCurrentSpeed()
    {
        return Input.Movement.Run.IsPressed() ? _runSpeed : _jumpForce;
    }

    private bool TryMove()
    {
        if (_controller.isGrounded == false)
        {
            return false;
        }

        Vector2 direction = Input.Movement.Move.ReadValue<Vector2>();

        if (direction.magnitude == 0f)
        {
            _moveDirection.x = 0f;
            _moveDirection.z = 0f;

            return false;
        }
        else
        {
            Move(direction);

            return true;
        }
    }

    private void Move(Vector2 direction)
    {
        Vector3 inputDirection = new Vector3(direction.x, 0f, direction.y);

        inputDirection = transform.TransformDirection(inputDirection);

        _moveDirection = inputDirection * _currentSpeed;
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

    private void Jump()
    {
        _moveDirection.y = _jumpForce;
    }
}
