using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    private MovementLogic _currentLogic;
    private CharacterController _controller;

    [Header("Speeds")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _runSpeed;
    [Header("Jump")]
    [SerializeField] private float _jumpForce;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();

        _currentLogic = new GroundMovementLogic(_moveSpeed, _runSpeed, _jumpForce, transform, _controller);
    }

    private void Update()
    {
        _currentLogic.Execute();
    }
}
