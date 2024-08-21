using System.Threading.Tasks;
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

public abstract class WeaponAttack : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] private float _damage;
    [SerializeField] private float _rate;
    [Space]
    [SerializeField] private LayerMask _searchLayers;

    protected bool CanAttack { get; private set; } = true;

    protected LayerMask SearchLayers => _searchLayers;
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
