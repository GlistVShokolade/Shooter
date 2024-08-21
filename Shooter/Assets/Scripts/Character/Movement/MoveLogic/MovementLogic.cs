using UnityEngine;

public abstract class MovementLogic
{
    public MovementLogic(CharacterController controller)
    {
        _controller = controller;
    }

    protected Vector3 _moveDirection;
    protected CharacterController _controller;
    protected CharacterInput Input => Character.Instance.Input;

    public abstract void Update();

    public void SetDirection(float x, float y, float z)
    {
        _moveDirection.x = x;
        _moveDirection.y = y;
        _moveDirection.z = z;
    }

    public void SetDirection(Vector3 direction)
    {
        _moveDirection = direction;
    }
}
