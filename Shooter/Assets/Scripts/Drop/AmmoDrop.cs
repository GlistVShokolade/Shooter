using UnityEngine;

public class AmmoDrop : Drop
{
    private Inventory Inventory => Inventory.Instance;

    [SerializeField] private AmmoType _type = AmmoType.Rifle;
    [SerializeField, Min(1)] private int _amount;

    public override void Pick()
    {
        Inventory.AddAmmo(_type, _amount);
        print($"�� ��������� {_amount} ������ � �����: {_type}");

        DropPicked?.Invoke();
    }

    public override bool TryPick()
    {
        print("������� ��������� ����!");

        if (Inventory.HasWeapon(_type))
        {
            print("=)");

            Pick();

            return true;
        }

        print("=(");
        return false;
    }
}
