using System.Collections;
using UnityEngine;

public class LittleRobotAttack : UnitAttack
{
    private readonly float _distance;

    private float DistanceToTarget => Vector3.Distance(Vision.Transform.position, Target.transform.position);

    public LittleRobotAttack(float damage, float rate, float distance, UnitVision vision, MonoBehaviour context) : base(damage, rate, vision, context)
    {
        _distance = distance;
    }

    public override bool TryAttack()
    {
        if (Target.Health.IsDied)
        {
            return false;
        }
        if (Coroutine != null)
        {
            return false;
        }

        Start(Target);

        return true;
    }

    protected override IEnumerator Attack()
    {
        while (DistanceToTarget <= _distance && Target.Health.IsDied == false)
        {
            Debug.Log("Попытка совершения атаки!");

            if (CanAttack == false)
            {
                yield return null;
            }

            Target.Health.TakeHealth(Damage);

            yield return WaitDelay();

            Debug.Log("Атака совершена!");
        }

        Debug.Log("Атака завершена!");

        Stop();
    }

    protected override void OnTargetDetect(Player player)
    {
        SetTarget(player);

        TryAttack();
    }

    protected override void OnTargetLost()
    {
        Stop();
    }
}