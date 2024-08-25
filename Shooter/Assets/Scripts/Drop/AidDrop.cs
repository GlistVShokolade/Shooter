using UnityEngine;

public class AidDrop : Drop
{
    [SerializeField] private int _amount;

    private void Pick(Health health)
    {
        health.AddHealth(_amount);

        print($"Current Health: {health.CurrentHealth}");

        DropPicked?.Invoke();
    }

    public override bool TryPick(Player player)
    {
        if (player.Health.IsFull == false)
        {
            Pick(player.Health);

            return true;
        }

        return false;
    }
}