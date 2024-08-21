using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private MovementLogic _currentLogic;

    private CharacterController _controller;

    [Header("Speeds")]
    [SerializeField, Min(0)] private float _moveSpeed;
    [SerializeField, Min(0)] private float _runSpeed;
    [Header("Jump")]
    [SerializeField, Min(0)] private float _jumpForce;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _currentLogic = new GroundMovementLogic(_moveSpeed, _runSpeed, _jumpForce, transform, _controller);
    }

    private void Update()
    {
        _currentLogic.Update();
    }
}
