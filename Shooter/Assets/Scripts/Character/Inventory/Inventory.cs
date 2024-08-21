using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [SerializeField] private Slot[] _slots;

    public Slot[] Slots => _slots;

    public Weapon CurrentWeapon { get; private set; }

    public void Init()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        AllowWeapon(_slots[0].Weapon);
        AllowWeapon(_slots[1].Weapon);
    }

    public void AllowWeapon(Weapon newWeapon)
    {
        var slots = from slot in _slots where slot.IsAviable == false && slot.Weapon.Attack == newWeapon.Attack select slot;

        if (slots.Count() == 0)
        {
            return;
        }

        slots.First().Allow();
    }

    public bool HasWeapon(AmmoType ammoType)
    {
        return _slots.Any(slot => slot.Weapon.Attack is IAmmoAttack && (slot.Weapon.Attack as IAmmoAttack).Ammo.Type == ammoType && slot.IsAviable);
    }
    
    public void AddAmmo(AmmoType type, int amount)
    {
        foreach (var slot in _slots)
        {
            Weapon weapon = slot.Weapon;

            if ((weapon.Attack is IAmmoAttack) == false)
            {
                continue;
            }

            Ammo ammo = (weapon.Attack as IAmmoAttack).Ammo;

            if (ammo.Type != type)
            {
                continue;
            }

            ammo.AddAmmo(amount);
        }
    }

    public void SetCurrentWeapon(Weapon newWeapon)
    {
        if (newWeapon == null)
        {
            throw new NullReferenceException(nameof(newWeapon));
        }

        CurrentWeapon = newWeapon;
    }
}   