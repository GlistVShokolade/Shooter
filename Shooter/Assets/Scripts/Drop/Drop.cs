using System;
using UnityEngine;

public abstract class Drop : MonoBehaviour
{
    public Action DropPicked;

    public abstract bool TryPick(Player player);
}