using System;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private PlayerInput _input;

    [SerializeField] private Inventory _inventory;

    public Weapon CurrentWeapon { get; private set; }

    public event Action<Weapon> WeaponSwitched;

    public void Init()
    {
        _input = new PlayerInput();

        _input.Player.Slot1.performed += context => TrySwitch(_inventory.Slots[0].Weapon);
        _input.Player.Slot2.performed += context => TrySwitch(_inventory.Slots[1].Weapon);

        TrySwitch(_inventory.Slots[0].Weapon);

        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private bool TrySwitch(Weapon newWeapon)
    {
        if (_inventory.HasWeapon(newWeapon))
        {
            Switch(newWeapon);
            
            return true;
        }

        return false;
    }

    private void Switch(Weapon newWeapon)
    {
        CurrentWeapon = newWeapon;

        WeaponSwitched?.Invoke(newWeapon);
    }
}
