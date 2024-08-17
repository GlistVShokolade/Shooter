
using System.Threading.Tasks;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected bool CanAttack { get; private set; } = true;

    [SerializeField] private float _damage;
    [SerializeField] private float _attackRate;

    public float Damage => _damage;
    public float AttackRate => _attackRate;

    public CharacterInput Input => Character.Instance.Input;

    public abstract bool TryAttack();
    public abstract void Attack();

    public async void StartAttackDelay()
    {
        DenyAttack();

        await Task.Delay((int)(_attackRate * 1000f));

        AllowAttack();
    }

    private void AllowAttack()
    {
        CanAttack = true;
    }

    private void DenyAttack()
    {
        CanAttack = false;
    }
}
