using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    private readonly List<Weapon> _weapons = new List<Weapon>();

    [SerializeField] private Weapon[] _startWeapons;

    public Weapon CurrentWeapon { get; private set; }
    public IReadOnlyList<Weapon> Weapons => _weapons;

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

        _weapons.AddRange(_startWeapons);
    }

    public void AddWeapon(Weapon newWeapon)
    {
        var weapons = from weapon in _weapons where weapon.Attack == weapon.Attack select weapon;

        if (weapons.Count() > 0)
        {
            return;
        }

        _weapons.Add(newWeapon);
    }

    public void RemoveWeapon(Weapon removedWeapon)
    {
        var weapons = from weapon in _weapons where weapon.Attack == weapon.Attack select weapon;

        if (weapons.Count() == 0)
        {
            return;
        }

        _weapons.Remove(removedWeapon);
    }

    public void RemoveWeapon(int index)
    {
        var weapons = from weapon in _weapons where weapon.Attack == _weapons[index].Attack select weapon;

        if (weapons.Count() == 0)
        {
            return;
        }

        _weapons.RemoveAt(index);
    }

    public bool HasWeapon(AmmoType ammoType)
    {
        print($"{_weapons.Count}");

        foreach (var weapon in _weapons)
        {
            if ((weapon.Attack is IAmmoAttack) == false)
            {
                continue;
            }
            if ((weapon.Attack as IAmmoAttack).Ammo.Type != ammoType)
            {
                continue;
            }

            return true;
        }

        return false;
    }
    
    public void AddAmmo(AmmoType type, int amount)
    {
        foreach (var weapon in _weapons)
        {
            if ((weapon.Attack is IAmmoAttack) == false)
            {
                return;
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