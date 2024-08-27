using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class UnitMove
{
    protected Health TargetHealth { get; private set; }

    protected NavMeshAgent Agent { get; }
    protected UnitVision Vision { get; }

    public UnitMove(float moveSpeed, float stopDistance, UnitVision vision, NavMeshAgent agent)
    {
        Vision = vision;
        Agent = agent;

        Agent.speed = moveSpeed;
        Agent.stoppingDistance = stopDistance;

        vision.PlayerDetected += OnDetect;
        vision.PlayerLosted += OnLost;
    }

    ~UnitMove()
    {
        Vision.PlayerDetected -= OnDetect;
        Vision.PlayerLosted -= OnLost;
    }

    protected void Move(Vector3 position)
    {
        Agent.SetDestination(position);
    }

    protected void MoveOn(Vector3 velocity)
    {
        Agent.velocity = velocity;
    }

    protected void SetTarget(Health health)
    {
        if (health == null)
        {
            throw new NullReferenceException(nameof(health));
        }

        TargetHealth = health;
    }

    public abstract bool TryMove(Vector3 position);

    protected virtual void OnDetect(Player player) { }
    protected virtual void OnLost() { }
}