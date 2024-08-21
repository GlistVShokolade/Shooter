using UnityEngine;

public class AmmoDrop : Drop
{
    private Inventory Inventory => Inventory.Instance;

    [SerializeField] private AmmoType _type = AmmoType.Rifle;
    [SerializeField, Min(1)] private int _amount;

    public override void Pick()
    {
        Inventory.AddAmmo(_type, _amount);
        print($"Вы подобрали {_amount} патрон с типом: {_type}");

        DropPicked?.Invoke();
    }

    public override bool TryPick()
    {
        print("Попытка подобрать дроп!");

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
