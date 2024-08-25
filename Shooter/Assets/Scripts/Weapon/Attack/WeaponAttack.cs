using System.Threading.Tasks;

public abstract class WeaponAttack : IWeaponAttack
{
    public WeaponAttack(int damage, float rate)
    {
        Input = new PlayerInput();

        Damage = damage;
        Rate = rate;

        Input.Enable();
    }

    ~WeaponAttack()
    {
        Input.Disable();
    }

    protected bool CanAttack { get; private set; } = true;

    public int Damage { get; }
    public float Rate { get; }

    public PlayerInput Input { get; }

    public abstract bool TryAttack();
    protected abstract void Attack();

    protected async void StartDelay()
    {
        CanAttack = false;

        await Task.Delay((int)(Rate * 1000f));

        CanAttack = true;
    }
}