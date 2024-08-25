using UnityEngine;

public abstract class HitBox : MonoBehaviour, IWeaponVisitor
{
    public abstract void Visit(Rifle attack, RaycastHit hit);
    public abstract void Visit(ShotgunAttack attack, RaycastHit hit);
}

public class UnitHitBox : HitBox
{
    public override void Visit(Rifle attack, RaycastHit hit)
    {
        throw new System.NotImplementedException();
    }

    public override void Visit(ShotgunAttack attack, RaycastHit hit)
    {
        throw new System.NotImplementedException();
    }
}
