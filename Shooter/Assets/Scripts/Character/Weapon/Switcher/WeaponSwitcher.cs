using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private Inventory Inventory => Inventory.Instance;
    private Slot[] Slots => Inventory.Slots;

    private CharacterInput Input => Character.Instance.Input;

    public event Action WeaponSwitched;

    public void Init()
    {
        Input.Inventory.Slot1.performed += context => TrySwitch(Slots[0]);
        Input.Inventory.Slot2.performed += context => TrySwitch(Slots[1]);

        TrySwitch(Slots[0]);
    }

    private bool TrySwitch(Slot slot)
    {
        if (slot.IsAviable)
        {
            Switch(slot.Weapon);

            return true;
        }

        return false;
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
