using UnityEngine;

public class HitBox : MonoBehaviour, IWeaponVisitor
{
    [SerializeField] private Health _health;
    [Space]
    [SerializeField] private ParticleSystem _particle;

    public Health Health => _health;

    public GameObject SpawnDecal(Vector3 normal, Vector3 position)
    {
        return Instantiate(_particle.gameObject, position, Quaternion.FromToRotation(position, -normal));
    }

    public void Visit(RifleAttack rifle, RaycastHit hit)
    {
        print("Попадание с винтовки");
    }

    public void Visit(ShotgunAttack shotgun, RaycastHit hit)
    {
        print("Попадание с дробовика");
    }
}