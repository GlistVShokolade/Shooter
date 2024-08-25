using System.Linq;
using UnityEngine;

public class WeaponSwitcherView : MonoBehaviour
{
    [SerializeField] private WeaponSwitcher _switcher;
    [SerializeField] private Inventory _inventory;

    private void OnEnable()
    {
        _switcher.WeaponSwitched += OnSwitch;
    }

    private void OnDisable()
    {
        _switcher.WeaponSwitched -= OnSwitch;
    }

    private void OnSwitch(Weapon newWeapon)
    {
        var weaponsForDisable = from slot in _inventory.Slots where slot.Weapon != newWeapon select slot.Weapon;

        foreach (var weapon in weaponsForDisable)
        {
            weapon.Disable();
        }

        newWeapon.Enable();
    }
}
