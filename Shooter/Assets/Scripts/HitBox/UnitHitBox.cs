using UnityEngine;

public class UnitHitBox : HitBox
{
    [SerializeField] private Health _health;

    public override void Visit(RifleAttack attack, RaycastHit hit)
    {
        ApplyDamage(attack.Damage, 1);

        print("You are got on unit from shotgun");
    }

    public override void Visit(ShotgunAttack attack, RaycastHit hit)
    {
        ApplyDamage(attack.Damage, 1);

        print("You are got on unit from shotgun");
    }

    private void ApplyDamage(int damage, int multiplayer)
    {
        _health.TakeHealth(damage * multiplayer);
    }
}
