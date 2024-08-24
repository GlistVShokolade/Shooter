using System;
using UnityEngine;

public abstract class UsableObject : MonoBehaviour, IUsable
{
    public bool IsUsed { get; set; }

    public Action ObjectUsed;
    public Action ObjectUnused;

    public abstract void Use();
}