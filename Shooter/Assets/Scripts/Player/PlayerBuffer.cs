using System.Collections.Generic;

public static class PlayerBuffer
{
    public static List<Player> Players { get; private set; } = new List<Player>();

    public static void Register(Player player)
    {
        if (player == null)
        {
            throw new System.NullReferenceException(nameof(player));
        }
        if (Players.Contains(player))
        {
            return;
        }

        Players.Add(player);
    }

    public static void Unregister(Player player)
    {
        if (player == null)
        {
            throw new System.NullReferenceException(nameof(player));
        }

        Players.Remove(player);
    }
}