using UnityEngine;

public abstract class WeaponRaycastAttack : WeaponAttack
{
    [SerializeField, Min(0)] private float _distance;
    [Space]
    [SerializeField] private bool _useSpread = true;
    [SerializeField, Min(0)] private float _spreadFactor = 0.1f;

    private Vector3 CameraDirection => Character.Instance.Camera.transform.forward;
    private Vector3 CameraPosition => Character.Instance.Camera.transform.position;

    protected RaycastHit GetHit()
    {
        Vector3 direction = _useSpread ? CameraDirection + GetSpread() : CameraDirection;

        Ray ray = new Ray(CameraPosition, direction);

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
            Random.Range(-_spreadFactor, _spreadFactor), 
            Random.Range(-_spreadFactor, _spreadFactor), 
            Random.Range(-_spreadFactor, _spreadFactor)
        );
    }

    protected abstract void Accept(IWeaponVisitor visitor, RaycastHit hit);
}   
