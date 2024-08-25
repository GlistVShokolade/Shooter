public class Rifle : Weapon, IAttackBehavier, IAmmoBehavier
{
    public WeaponAttack Attack { get; set; }
    public Ammo Ammo { get; set; }
}