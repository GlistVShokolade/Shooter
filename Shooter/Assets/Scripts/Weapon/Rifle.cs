using UnityEngine;

public class Rifle : Weapon, IAttackBehavier, IAmmoBehavier
{
    public WeaponAttack Attack { get; set; }

    [field: SerializeField] public Ammo Ammo { get; set; }
    [Space]
    [SerializeField] private Transform _cameraTransform;
    [Space]
    [SerializeField] private AmmoSpendType _spendType;
    [Space]
    [SerializeField, Min(0f)] private float _damage;
    [SerializeField, Min(0f)] private float _rate;
    [SerializeField, Min(0f)] private float _spreadFactor;
    [SerializeField, Min(0)] private int _shootCount;
    [SerializeField, Min(0f)] private float _distance;

    private void Start()
    {
        Attack = new RifleAttack(_damage, _rate, _distance, _shootCount, _spreadFactor, _spendType, _cameraTransform, Ammo);
    }

    private void Update()
    {
        Attack.TryAttack();
    }
}