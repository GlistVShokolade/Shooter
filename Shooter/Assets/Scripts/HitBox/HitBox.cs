using UnityEngine;

public class HitBox : MonoBehaviour, IWeaponVisitor
{
    [SerializeField] private Health _health;
    [Space]
    [SerializeField] private ParticleSystem _particle;

    protected Health Health => _health;

    public void Visit(RifleAttack attack, RaycastHit hit)
    {
        ApplyDamage(attack);

        print("Попадание с винтовки");
    }

    public void Visit(ShotgunAttack attack, RaycastHit hit)
    {
        ApplyDamage(attack);

        print("Попадание с дробовика");
    }

    protected void ApplyDamage(WeaponAttack attack)
    {
        _health.ApplyDamage(attack.Damage);
    }

    protected GameObject SpawnDecal(Vector3 normal, Vector3 position)
    {
        return Instantiate(_particle.gameObject, position, Quaternion.LookRotation(normal));
    }
}