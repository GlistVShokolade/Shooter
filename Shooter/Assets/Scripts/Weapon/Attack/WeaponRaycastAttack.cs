using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponRaycastAttack : WeaponAttack
{
    public WeaponRaycastAttack(int damage, float rate, float distance, int shootCount, float spreadFactor, Transform cameraTransform) : base(damage, rate)
    {
        _cameraTransform = cameraTransform;
        _spreadFactor = spreadFactor;

        ShootCount = shootCount;
        Distance = distance;
    }

    public int ShootCount { get; }
    public float Distance { get; }

    private readonly float _spreadFactor;
    private readonly Transform _cameraTransform;

    protected RaycastHit[] GetHits()
    {
        RaycastHit[] hits = new RaycastHit[ShootCount];

        for (int i = 0; i < ShootCount; i++)
        {
            Ray Ray = new Ray(_cameraTransform.position, _cameraTransform.forward + CalculateSpread());

            Physics.Raycast(Ray, out RaycastHit hit, Distance);

            hits[i] = hit;

            Debug.Log(i);
        }

        return hits;
    }

    protected IWeaponVisitor ScanHit(RaycastHit hit)
    {
        if (hit.collider == null)
        {
            return null;
        }

        return hit.collider.GetComponent<IWeaponVisitor>();
    }

    protected List<IWeaponVisitor> ScanHits(RaycastHit[] hits)
    {
        List<IWeaponVisitor> visitors = new List<IWeaponVisitor>();

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.TryGetComponent(out IWeaponVisitor visitor) == false)
            {
                continue;
            }

            visitors.Add(visitor);
        }

        return visitors;
    }

    private Vector3 CalculateSpread()
    {
        return new Vector3
        (
            Random.Range(-_spreadFactor, _spreadFactor),
            Random.Range(-_spreadFactor, _spreadFactor),
            Random.Range(-_spreadFactor, _spreadFactor)
        );
    }

    protected abstract void Accept(IWeaponVisitor visitor, RaycastHit hit);
}
