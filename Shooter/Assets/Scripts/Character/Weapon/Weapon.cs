
using System.Threading.Tasks;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected bool CanAttack { get; private set; } = true;

    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackRate;
    [Space]
    [SerializeField] private LayerMask _searchLayers;
    [Space]
    [SerializeField] private float _spreadValue;

    public float AttackDamage => _attackDamage;
    public float AttackRate => _attackRate;
    public float AttackDistance => _attackDistance;
    public LayerMask SearchLayers => _searchLayers;
    public float SpreadValue => _spreadValue;

    public CharacterInput Input => Character.Instance.Input;

    public abstract bool TryAttack();
    public abstract void Attack();

    public async void StartAttackDelay()
    {
        CanAttack = false;

        await Task.Delay((int)(_attackRate * 1000f));

        CanAttack = true;
    }

    public Vector3 GetSpread()
    {
        return new Vector3
            (
            Random.Range(-_spreadValue, _spreadValue),
            Random.Range(-_spreadValue, _spreadValue), 
            Random.Range(-_spreadValue, _spreadValue)
            );
    }
}
