using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Slot[] _slots;
    [Space]
    [SerializeField] private Weapon[] _startWeapons;

    public void Init()
    {
        AddStartWeapons();
    }

    private void AddStartWeapons()
    {
        foreach (var weapon in _startWeapons)
        {
            AddWeapon(weapon);
        }
    }

    public bool HasWeapon(Weapon newWeapon)
    {
        return _slots.Any(slot => slot.Weapon.GetType() == newWeapon.GetType() && slot.IsAvailable);
    }

    public Weapon GetWeapon(AmmoType ammoType)
    {
        IEnumerable<Slot> allegedSlots = _slots.Where(slot => slot.IsAvailable && (slot.Weapon is IAmmoBehavier) && (slot.Weapon as IAmmoBehavier).Ammo.Type == ammoType);

        if (allegedSlots.Count() == 0)
        {
            return null;
        }

        return allegedSlots.FirstOrDefault().Weapon;
    }

    public void AddWeapon(Weapon newWeapon)
    {
        if (HasWeapon(newWeapon))
        {
            return;
        }

        IEnumerable<Slot> allegedSlots = _slots.Where(slot => slot.IsAvailable == false && slot.Weapon.GetType() == newWeapon.GetType());

        allegedSlots.FirstOrDefault().GiveAcces();
    }
}
