using System;
using UnityEngine;

public abstract class Drop : MonoBehaviour, IDrop
{
    public Action DropPicked;

    public abstract void Pick();
    public abstract bool TryPick();
}