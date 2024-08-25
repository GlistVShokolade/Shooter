using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public Inventory Inventory { get; private set; }
    [field: SerializeField] public WeaponSwitcher WeaponSwitcher { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }

    public void Start()
    {
        Inventory.Init();
        WeaponSwitcher.Init();
    }
}
