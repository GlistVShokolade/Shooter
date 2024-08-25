using UnityEngine;

public interface IWeaponVisitor
{
    public void Visit(RifleAttack attack, RaycastHit hit);
    public void Visit(ShotgunAttack attack, RaycastHit hit);
}