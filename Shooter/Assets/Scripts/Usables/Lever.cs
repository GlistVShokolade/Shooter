using System;
using UnityEngine;

public class Lever : MonoBehaviour, IUsable
{
    public bool IsUsed { get; set; }

    public event Action LeverEnabled;
    public event Action LeverDisabled;

    public void Use()
    {
        if (IsUsed)
        {
            LeverDisabled?.Invoke();

            IsUsed = false;
        }
        else
        {
            LeverEnabled?.Invoke();

            IsUsed = true;
        }
    }
}
