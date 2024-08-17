using UnityEngine;

public class HitBox : MonoBehaviour, IWeaponVisitor
{
    [SerializeField] private Health _health;
    [Space]
    [SerializeField] private GameObject _decal;

    public Health Health => _health;

    public void Visit(Pistol pistol, RaycastHit hit)
    {
        Debug.Log("Выстрел из пистолета!");

        _health.ApplyDamage(pistol.AttackDamage);
        SpawnDecal(hit.normal, hit.point);
    }

    public GameObject SpawnDecal(Vector3 normal, Vector3 position)
    {
        return Instantiate(_decal, position, Quaternion.FromToRotation(position, -normal));
    }
}