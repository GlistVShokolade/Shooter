using System;
using System.Collections;
using UnityEngine;

public abstract class UnitAttack
{
    protected bool CanAttack { get; private set; } = true;

    protected float Damage { get; }
    protected float Rate { get; }

    private MonoBehaviour Context { get; }

    protected Transform Transform { get; }
    protected Coroutine Coroutine { get; private set; }
    protected UnitVision Vision { get; }

    protected Player Target { get; private set; }

    public UnitAttack(float damage, float rate, Transform transform, UnitVision vision, MonoBehaviour context)
    {
        Damage = damage;
        Rate = rate;

        Transform = transform;
        Vision = vision;
        Context = context;

        vision.PlayerDetected += OnTargetDetect;
        vision.PlayerLosted += OnTargetLost;
    }

    ~UnitAttack()
    {
        Vision.PlayerDetected -= OnTargetDetect;
        Vision.PlayerLosted -= OnTargetLost;
    }

    protected void Start(Player player)
    {
        Coroutine = Context.StartCoroutine(Attack());
    }

    protected void Stop()
    {
        if (Coroutine == null)
        {
            return;
        }

        Context.StopCoroutine(Coroutine);

        Coroutine = null;
    }

    protected void SetTarget(Player player)
    {
        if (player == null)
        {
            throw new NullReferenceException(nameof(player));
        }

        Target = player;
    }

    protected IEnumerator WaitDelay()
    {
        CanAttack = false;

        yield return new WaitForSeconds(Rate);

        CanAttack = true;
    }

    public abstract bool TryAttack();
    protected abstract IEnumerator Attack();

    protected virtual void OnTargetDetect(Player player) { }
    protected virtual void OnTargetLost() { }
}