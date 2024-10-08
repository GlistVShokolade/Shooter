using System.Collections;
using UnityEngine;

public class LittleRobotAttack : UnitAttack
{
    private readonly float _distance;

    private float DistanceToTarget => Vector3.Magnitude(Transform.position - Target.transform.position);

    public LittleRobotAttack(float damage, float rate, float distance, UnitVision vision, Transform transform, MonoBehaviour context) : base(damage, rate, transform, vision, context)
    {
        _distance = distance;
    }

    public override bool TryAttack()
    {
        if (CoroutineStarted)
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
            Debug.Log("������� ���������� �����!");

            if (CanAttack == false)
            {
                yield return null;
            }

            Target.Health.TakeHealth(Damage);

            yield return WaitDelay();

            Debug.Log("����� ���������!");
        }

        Debug.Log("����� ���������!");

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