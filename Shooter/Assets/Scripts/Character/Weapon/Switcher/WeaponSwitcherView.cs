using UnityEngine;

public class WeaponSwitcherView : MonoBehaviour
{
    [SerializeField] private WeaponSwitcher _switcher;

    private Inventory Inventory => Inventory.Instance;
    private Slot[] Slots => Inventory.Slots;

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
        foreach (var slot in Slots)
        {
            slot.Weapon.Disable();
        }

        Inventory.CurrentWeapon.Enable();
    }
}
