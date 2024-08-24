using System.Threading.Tasks;
using UnityEngine;

public abstract class WeaponAttack : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField, Min(0)] private int _damage;
    [SerializeField, Min(0.01f)] private float _rate;
    [Space]
    [SerializeField] private LayerMask _searchLayers;

    public int Damage => _damage;
    protected LayerMask SearchLayers => _searchLayers;

    protected bool CanAttack { get; private set; } = true;

    protected CharacterInput Input => Character.Instance.Input;

    public abstract bool TryAttack();
    protected abstract void Attack();

    protected async void StartDelay()
    {
        CanAttack = false;

        await Task.Delay((int)(_rate * 1000f));

        CanAttack = true;
    }
}
