using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponOverlapAttack : WeaponAttack
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _radius;

    protected Collider[] GetColliders()
    {
        Collider[] colliders = Physics.OverlapSphere(_center.position, _radius);

        return colliders;
    }

    protected List<IWeaponVisitor> ScanColliders(Collider[] colliders)
    {
        List<IWeaponVisitor> visitors = new List<IWeaponVisitor>();

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IWeaponVisitor damagable))
            {
                visitors.Add(damagable);
            }
        }

        return visitors;
    }
}
