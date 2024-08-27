using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class LittleRobot : Unit
{
    private UnitAttack _attack;
    private UnitMove _move;
    private UnitVision _vision;

    private void Awake()
    {
        var agent = GetComponent<NavMeshAgent>();

        _vision = new UnitVision(20f, 3f, transform);
        _attack = new LittleRobotAttack(10f, 1f, 10f, _vision, transform, this);
        _move = new LittleRobotMove(3f, 8f, _vision, agent);
    }

    private void Start()
    {
        StartCoroutine(_vision.Scan());
    }
} 