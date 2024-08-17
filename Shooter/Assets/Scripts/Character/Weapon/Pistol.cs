using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Attack()
    {
        StartAttackDelay();

        Transform cameraTransform = Character.Instance.Camera.transform;

        Vector3 spread = SpreadValue == 0f ? Vector3.zero : GetSpread();

        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward + spread);

        if (Physics.Raycast(ray, out RaycastHit hit, AttackDistance, SearchLayers) == false)
        {
            return;
        }
        if (hit.transform.TryGetComponent(out IWeaponVisitor visitor) == false)
        {
            return;
        }

        visitor.Visit(this, hit);
    }

    public override bool TryAttack()
    {
        if (CanAttack == false)
        {
            return false;
        }
        if (Input.Attachment.Attack.IsPressed() == false)
        {
            return false;
        }

        Attack();

        return true;
    }
}
