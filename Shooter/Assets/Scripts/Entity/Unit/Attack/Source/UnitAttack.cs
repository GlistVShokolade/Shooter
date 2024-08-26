public abstract class UnitAttack
{
    protected UnitVision Vision { get; }

    public UnitAttack(UnitVision vision)
    {
        Vision = vision;
    }

    public abstract bool TryAttack();
    protected abstract void Attack();
}