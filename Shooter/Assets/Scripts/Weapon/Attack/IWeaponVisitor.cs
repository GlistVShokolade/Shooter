using UnityEngine;

public interface IWeaponVisitor
{
    public void Visit(Rifle attack, RaycastHit hit);
    public void Visit(ShotgunAttack attack, RaycastHit hit);
}