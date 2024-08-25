using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [field: SerializeField] public Slot[] Slots { get; private set; }
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
        return Slots.Any(slot => slot.Weapon.GetType() == newWeapon.GetType() && slot.IsAvailable);
    }

    public Weapon GetWeapon(AmmoType ammoType)
    {
        IEnumerable<Slot> allegedSlots = Slots.Where(slot => slot.IsAvailable && (slot.Weapon is IAmmoBehavier) && (slot.Weapon as IAmmoBehavier).Ammo.Type == ammoType);

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

        IEnumerable<Slot> allegedSlots = Slots.Where(slot => slot.IsAvailable == false && slot.Weapon.GetType() == newWeapon.GetType());

        allegedSlots.FirstOrDefault().GiveAcces();
    }
}
