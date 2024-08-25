using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;
    private CharacterController _controller;

    private IMovementLogic _currentLogic;

    [SerializeField] private float _walkSpeed, _runSpeed, _jumpHeight;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _input = new PlayerInput();

        _input.Enable();

        _currentLogic = new GroundMovementLogic(_walkSpeed, _runSpeed, _jumpHeight, _controller, _input, transform);
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        _currentLogic.Execute();
    }
}