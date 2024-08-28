using System;
using System.Collections;
using UnityEngine;

public abstract class UnitAttack
{
    private readonly WaitForSeconds _delay;
    private readonly MonoBehaviour _context;

    private Coroutine _coroutine;

    protected bool CoroutineStarted => _coroutine != null;
    protected bool CanAttack { get; private set; } = true;

    protected float Damage { get; }
    protected float Rate { get; }

    protected Transform Transform { get; }
    protected UnitVision Vision { get; }

    protected Player Target { get; private set; }

    public UnitAttack(float damage, float rate, Transform transform, UnitVision vision, MonoBehaviour context)
    {
        Damage = damage;
        Rate = rate;

        Transform = transform;
        Vision = vision;

        _context = context;
        _delay = new WaitForSeconds(Rate);

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
        _coroutine = _context.StartCoroutine(Attack());
    }

    protected void Stop()
    {
        if (_coroutine == null)
        {
            return;
        }

        _context.StopCoroutine(_coroutine);

        _coroutine = null;
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

        yield return _delay;

        CanAttack = true;
    }

    public abstract bool TryAttack();
    protected abstract IEnumerator Attack();

    protected virtual void OnTargetDetect(Player player) { }
    protected virtual void OnTargetLost() { }
}