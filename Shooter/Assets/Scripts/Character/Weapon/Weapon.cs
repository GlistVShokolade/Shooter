using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponAttack _attack;

    private void Update()
    {
        _attack.TryAttack();
    }
}

public abstract class WeaponAttack : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] private float _damage;
    [SerializeField] private float _rate;
    [Space]
    [SerializeField] private LayerMask _searchLayers;

    protected bool CanAttack { get; private set; } = true;

    protected LayerMask SearchLayers => _searchLayers;
    protected CharacterInput Input => Character.Instance.Input;

    public abstract bool TryAttack();
    protected abstract void Attack();

    protected async void StartDelay()
    {
        CanAttack = false;

        await Task.Delay((int)(_rate * 1000f));

        CanAttack = true;
    }
}

public abstract class WeaponRaycastAttack : WeaponAttack
{
    [SerializeField] private float _distance;
    [SerializeField] private float _spread;

    protected RaycastHit GetHit()
    {
        Transform cameraTransform = Character.Instance.Camera.transform;

        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward + GetSpread());

        Physics.Raycast(ray, out RaycastHit hit, _distance, SearchLayers);

        return hit;
    }

    protected IWeaponVisitor ScanHit(RaycastHit hit)
    {
        if (hit.collider == null)
        {
            return null;
        }
        if (hit.collider.TryGetComponent(out IWeaponVisitor visitor))
        {
            return visitor;
        }

        return null;
    }

    private Vector3 GetSpread()
    {
        return new Vector3
        (
            Random.Range(-_spread, _spread), 
            Random.Range(-_spread, _spread), 
            Random.Range(-_spread, _spread)
        );
    }

    protected abstract void Accept(IWeaponVisitor visitor, RaycastHit hit);
}   

public abstract class WeaponOverlapAttack : WeaponAttack
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _radius;

    protected Collider[] GetColliders()
    {
        Collider[] colliders = Physics.OverlapSphere(_center.position, _radius);

        return colliders;
    }

    protected List<IDamagable> ScanColliders(Collider[] colliders)
    {
        List<IDamagable> damagables = new List<IDamagable>();

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IDamagable damagable))
            {
                damagables.Add(damagable);
            }
        }

        return damagables;
    }
}
