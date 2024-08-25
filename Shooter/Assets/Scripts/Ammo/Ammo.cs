using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private int _currentAmmo;

    [SerializeField, Min(0)] private int _startAmmo;
    [SerializeField, Min(0)] private int _maxAmmo;

    public int CurrentAmmo
    {
        get { return _currentAmmo; }
        private set { _currentAmmo = Math.Clamp(value, 0, _maxAmmo); }
    }

    public event Action AmmoChanged;

    private void Start()
    {
        AddAmmo(_startAmmo);
    }

    public void AddAmmo(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        CurrentAmmo += amount;

        AmmoChanged?.Invoke();
    }

    public void TakeAmmo(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        CurrentAmmo -= amount;

        AmmoChanged?.Invoke();
    }
}