using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class LittleRobot : Unit
{
    private NavMeshAgent _agent;

    private UnitVision _vision;
    private UnitAttack _attack;
    private UnitMove _move;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _vision = GetComponent<UnitVision>();

        _attack = null;
        _move = null;
    }
}