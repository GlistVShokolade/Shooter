using UnityEngine;

public class ShotgunAttack : WeaponRaycastAttack
{
    public ShotgunAttack(int damage, float rate, float distance, int shootCount, float spreadFactor, AmmoSpendType spendType, Transform cameraTransform, Ammo ammo) : base(damage, rate, distance, shootCount, spreadFactor, cameraTransform)
    {
        _ammo = ammo;
        _spendType = spendType;
    }

    private readonly Ammo _ammo;
    private readonly AmmoSpendType _spendType;


    public override bool TryAttack()
    {
        if (CanAttack == false)
        {
            return false;
        }
        if (_ammo.CurrentAmmo == 0)
        {
            return false;
        }
        if (Input.Player.Attack.IsPressed() == false)
        {
            return false;
        }

        Attack();

        return true;
    }

    protected override void Attack()
    {
        StartDelay();

        SpendAmmo();

        RaycastHit[] hits = GetHits();
        
        foreach (RaycastHit hit in hits)
        {
            IWeaponVisitor visitor = ScanHit(hit);

            Debug.Log("Attack performed!");

            if (visitor == null)
            {
                continue;
            }

            Accept(visitor, hit);
        }
    }

    private void SpendAmmo()
    {
        switch (_spendType)
        {
            case AmmoSpendType.Single:
                _ammo.TakeAmmo(1);
                break;
            case AmmoSpendType.PerEveryone:
                _ammo.TakeAmmo(ShootCount);
                break;
        }
    }

    protected override void Accept(IWeaponVisitor visitor, RaycastHit hit) => visitor.Visit(this, hit);
}
