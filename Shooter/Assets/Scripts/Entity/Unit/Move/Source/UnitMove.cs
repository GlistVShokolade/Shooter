using UnityEngine;

public abstract class UnitMove
{
    protected UnitVision Vision { get; }

    public UnitMove(UnitVision vision)
    {
        Vision = vision;
    }

    public abstract bool TryMove(Vector3 position);
    protected abstract void Move(Vector3 position);
}