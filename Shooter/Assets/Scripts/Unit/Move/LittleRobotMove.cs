using UnityEngine;
using UnityEngine.AI;

public class LittleRobotMove : UnitMove
{
    public LittleRobotMove(float moveSpeed, float stopDistance, UnitVision vision, NavMeshAgent agent) : base(moveSpeed, stopDistance, vision, agent)
    {

    }

    public override bool TryMove(Vector3 position)
    {
        if (TargetHealth.IsDied)
        {
            return false;
        }

        Move(position);

        return true;
    }

    protected override void OnDetect(Player player)
    {
        SetTarget(player.Health);

        TryMove(player.transform.position);
    }
}