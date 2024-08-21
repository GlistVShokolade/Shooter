using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private WeaponSwitcher _switcher;

    private void Start()
    {
        _inventory.Init();
        _switcher.Init();
    }
}