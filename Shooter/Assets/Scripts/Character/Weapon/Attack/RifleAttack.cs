using UnityEngine;

public class RifleAttack : WeaponRaycastAttack, IAmmoAttack
{
    [field: SerializeField] public Ammo Ammo { get; set; }

    public override bool TryAttack()
    {
        if (CanAttack == false)
        {
            return false;
        }
        if (Ammo.CurrentAmmo == 0)
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

    protected override void Attack()
    {
        StartDelay();

        Ammo.TakeAmmo(1);

        RaycastHit hit = GetHit();
        IWeaponVisitor visitor = ScanHit(hit);

        if (visitor == null)
        {
            return;
        }

        Accept(visitor, hit);
    }

    protected override void Accept(IWeaponVisitor visitor, RaycastHit hit) => visitor.Visit(this, hit);
}
