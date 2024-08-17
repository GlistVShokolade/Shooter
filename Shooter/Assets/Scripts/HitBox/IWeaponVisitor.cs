using UnityEngine;

public interface IWeaponVisitor
{
    public void Visit(Pistol pistol, RaycastHit hit);
}