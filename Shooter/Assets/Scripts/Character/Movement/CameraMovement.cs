using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float _rotationX;

    [SerializeField] private float _sensitivity;
    [Space]
    [SerializeField] private Transform _character;

    private CharacterInput Input => Character.Instance.Input;
    private Vector2 MouseDelta => Input.Movement.MouseDelta.ReadValue<Vector2>();

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        Vector2 currentMouseDelta = MouseDelta * (_sensitivity * Time.deltaTime);

        _rotationX -= currentMouseDelta.y;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

        _character.Rotate(Vector3.up * currentMouseDelta.x);
        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
    }
}
