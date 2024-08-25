using UnityEngine;

public class AmmoDrop : Drop
{
    [SerializeField] private int _amount;
    [SerializeField] private AmmoType _type;

    public override bool TryPick(Player player)
    {
        Weapon weapon = player.Inventory.GetWeapon(_type);

        if (weapon == null)
        {
            return false;
        }

        Ammo ammo = (weapon as IAmmoBehavier).Ammo;

        print("�������� ������");

        if (ammo == null)
        {
            return false;
        }

        Pick(ammo);

        return true;
    }

    private void Pick(Ammo ammo)
    {
        ammo.AddAmmo(_amount);

        print($"�� ��������� {_amount} ������ ���� {_type}");

        DropPicked?.Invoke();
    }
}