using UnityEngine;

public class AidDrop : Drop
{
    private Health PlayerHealth => Character.Instance.Health;

    [SerializeField, Min(0)] private int _amount;

    public override void Pick()
    {
        PlayerHealth.AddHealth(_amount);

        DropPicked?.Invoke();
    }

    public override bool TryPick()
    {
        if (PlayerHealth.CurrentHealth < PlayerHealth.MaxHealth)
        {

            Pick();

            return true;
        }

        return false;
    }
}
