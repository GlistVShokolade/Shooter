using UnityEngine;

public class Weapon : MonoBehaviour, IEnable
{
    [SerializeField] private WeaponAttack _attack;

    public WeaponAttack Attack => _attack;

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        _attack.TryAttack();
    }
}
