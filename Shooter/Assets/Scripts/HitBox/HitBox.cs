using UnityEngine;

public abstract class HitBox : MonoBehaviour, IWeaponVisitor
{
    public abstract void Visit(RifleAttack attack, RaycastHit hit);
    public abstract void Visit(ShotgunAttack attack, RaycastHit hit);
}
