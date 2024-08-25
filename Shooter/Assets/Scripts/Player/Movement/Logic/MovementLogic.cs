using UnityEngine;

public abstract class MovementLogic : IMovementLogic
{
    protected Vector3 MoveDirection;

    protected Vector3 Gravity = new Vector3(0f, -9.81f, 0f);

    public abstract void Execute();
}
