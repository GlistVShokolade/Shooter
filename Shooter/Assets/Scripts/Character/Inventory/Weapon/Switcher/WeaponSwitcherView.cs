using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcherView : MonoBehaviour
{
    [SerializeField] private WeaponSwitcher _switcher;

    private Inventory Inventory => Inventory.Instance;
    private IReadOnlyList<Weapon> Weapons => Inventory.Weapons;

    private void OnEnable()
    {
        _switcher.WeaponSwitched += OnSwitch;
    }

    private void OnDisable()
    {
        _switcher.WeaponSwitched -= OnSwitch;
    }

    private void OnSwitch()
    {
        foreach (var weapon in Weapons)
        {
            weapon.Disable();
        }

        Inventory.CurrentWeapon.Enable();
    }
}
