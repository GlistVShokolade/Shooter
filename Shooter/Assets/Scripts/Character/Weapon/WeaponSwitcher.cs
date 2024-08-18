using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private Weapon _currentWeapon;

    [SerializeField] private Weapon[] _weapons;

    private CharacterInput Input => Character.Instance.Input;

    private void Start()
    {
        Input.Inventory.Slot1.started += context => Switch(_weapons[0]);
        Input.Inventory.Slot2.started += context => Switch(_weapons[1]);

        Switch(_weapons[0]);
    }

    private void Switch(Weapon newWeapon)
    {
        _currentWeapon = newWeapon;

        foreach (var weapon in _weapons)
        {
            weapon.gameObject.SetActive(false);
        }

        _currentWeapon.gameObject.SetActive(true);
    }
}
