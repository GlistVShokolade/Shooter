using UnityEngine;
using UnityEngine.AI;

public class LittleRobotMove : UnitMove
{
    public LittleRobotMove(UnitVision vision, NavMeshAgent agent) : base(vision, agent)
    {
    }

    public override bool TryMove(Vector3 position)
    {
        throw new System.NotImplementedException();
    }

    protected override void Move(Vector3 position)
    {
        throw new System.NotImplementedException();
    }
}