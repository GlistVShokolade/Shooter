using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private const float MaxRotationX = 90f;
    private const float MinRotationX = -MaxRotationX;

    private float _rotationX;

    [SerializeField, Min(0f)] private float _sensitivity;
    [Space]
    [SerializeField] private Transform _character;

    private CharacterInput Input => Character.Instance.Input;
    private Vector2 MouseDelta => Input.Movement.MouseDelta.ReadValue<Vector2>();

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        TryRotate();
    }

    private bool TryRotate()
    {
        Vector2 mouseDelta = MouseDelta * (_sensitivity * Time.deltaTime);

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

        _character.Rotate(Vector3.up * mouseDelta.x);

        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
    }
}
