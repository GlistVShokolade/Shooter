using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [Header("Ammo")]
    [SerializeField] private int _startAmmo;
    [SerializeField] private int _maxAmmo;

    private int _savedAmmo, _currentAmmo;

    public int MaxAmmo => _maxAmmo;
    public int SavedAmmo => _savedAmmo;

    public bool HasAmmo => (_currentAmmo + _savedAmmo) > 0;

    public int CurrentAmmo
    {
        get { return _currentAmmo; }
        private set { _currentAmmo = Math.Clamp(value, 0, _maxAmmo); }
    }

    public event Action AmmoChanged;

    private void Awake()
    {
        CurrentAmmo = _startAmmo;
    }

    public void TakeAmmo(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        CurrentAmmo -= amount;
    }

    public void AddAmmo(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        _savedAmmo += amount;
    }
}
