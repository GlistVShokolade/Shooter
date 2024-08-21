using System;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [field: SerializeField] public Weapon Weapon { get; private set; }

    public bool IsAviable { get; private set; } = false;

    public event Action IsAllowed;
    public event Action IsDenied;

    public void Allow()
    {
        IsAviable = true;

        IsAllowed?.Invoke();
    }

    public void Deny()
    {
        IsAviable = false;

        IsDenied?.Invoke();
    }
}

public class SlotView : MonoBehaviour
{
    [SerializeField] private Slot _slot;

    private void OnEnable()
    {
        _slot.IsAllowed += OnAllow;
        _slot.IsDenied += OnDeny;
    }

    private void OnDisable()
    {
        _slot.IsAllowed -= OnAllow;
        _slot.IsDenied -= OnDeny;
    }

    private void OnAllow()
    {
        _slot.Weapon.Enable();
    }

    private void OnDeny()
    {
        _slot.Weapon.Disable();
    }
}