using UnityEngine;

public interface IWeaponVisitor
{
    public void Visit(RifleAttack rifle, RaycastHit hit);
    public void Visit(ShotgunAttack shotgun, RaycastHit hit);
}