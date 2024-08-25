using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(Health))]
public class ItemHitBox : HitBox
{
    private Rigidbody _rigidbody;

    [SerializeField] private Health _health;
    [Space]
    [SerializeField] private bool _usePush;
    [SerializeField] private float _pushForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public override void Visit(RifleAttack attack, RaycastHit hit)
    {
        _health.TakeHealth(attack.Damage);

        TryPush(-hit.normal);

        print("You are got on item from rifle");
    }

    public override void Visit(ShotgunAttack attack, RaycastHit hit)
    {
        _health.TakeHealth(attack.Damage);

        TryPush(-hit.normal);

        print("You are got on item from shotgun");
    }

    public void Push(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _pushForce, ForceMode.Impulse);
    }

    private bool TryPush(Vector3 direction)
    {
        if (_rigidbody != null && _usePush)
        {
            Push(direction);

            return true;
        }

        return false;
    }
}
