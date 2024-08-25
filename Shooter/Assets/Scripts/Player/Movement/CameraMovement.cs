using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private const float MaxRotationX = 90f;
    private const float MinRotationX = -MaxRotationX;

    private PlayerInput _input;
    private float _rotationX;

    [SerializeField] private Transform _playerTransform;
    [Space]
    [SerializeField] private float _sensitivity;

    private Vector2 InputMouseDelta => _input.Player.MouseDelta.ReadValue<Vector2>();

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        _input = new PlayerInput();

        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        TryRotate();
    }

    private bool TryRotate()
    {
        Vector2 mouseDelta = InputMouseDelta * (_sensitivity * Time.fixedDeltaTime);

        if (mouseDelta != Vector2.zero)
        {
            Rotate(mouseDelta);

            return true;
        }

        return false;
    }

    private void Rotate(Vector2 mouseDelta)
    {
        _rotationX -= mouseDelta.y;
        _rotationX = Mathf.Clamp(_rotationX, MinRotationX, MaxRotationX);

        _playerTransform.Rotate(Vector3.up * mouseDelta.x);
        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
    }
}