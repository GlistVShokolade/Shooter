using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private Inventory Inventory => Inventory.Instance;
    private IReadOnlyList<Weapon> Weapons => Inventory.Weapons;

    private CharacterInput Input => Character.Instance.Input;

    public event Action WeaponSwitched;

    public void Init()
    {
        Input.Inventory.Slot1.started += context => Switch(Weapons[0]);
        Input.Inventory.Slot2.started += context => Switch(Weapons[1]);

        Switch(Weapons[0]);
    }

    private void Switch(Weapon newWeapon)
    {
        if (newWeapon == null)
        {
            throw new NullReferenceException(nameof(newWeapon));
        }

        Inventory.SetCurrentWeapon(newWeapon);

        WeaponSwitched?.Invoke();
    }
}
