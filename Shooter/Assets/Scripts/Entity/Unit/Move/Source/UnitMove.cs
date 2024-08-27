using UnityEngine;
using UnityEngine.AI;

public abstract class UnitMove
{
    protected NavMeshAgent Agent { get; }
    protected UnitVision Vision { get; }

    public UnitMove(UnitVision vision, NavMeshAgent agent)
    {
        Vision = vision;
        Agent = agent;
    }

    public abstract bool TryMove(Vector3 position);
    protected abstract void Move(Vector3 position);
}