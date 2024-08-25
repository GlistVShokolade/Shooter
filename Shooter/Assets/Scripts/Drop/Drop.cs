using System;
using UnityEngine;

public abstract class Drop : MonoBehaviour, IDrop
{
    public Action DropPicked;

    public abstract bool TryPick(Player player);
}