using System;
using Unity.VisualScripting;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AmmoType _type;
    [Space]
    [SerializeField] private int _startAmmo;
    [SerializeField] private int _maxAmmo;

    public AmmoType Type => _type;

    private int _savedAmmo;

    public int StartAmmo => _startAmmo;
    public int MaxAmmo => _maxAmmo;
    
    public int CurrentAmmo
    {
        get
        {
            return CurrentAmmo;
        }
        private set
        {
            CurrentAmmo = Math.Clamp(value, 0, _maxAmmo);
        }
    }

    private void Awake()
    {
        CurrentAmmo = _startAmmo;
    }

    public bool HasAmmo(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        return CurrentAmmo - amount > 0;
    }

    public void TakeAmmo(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        _savedAmmo -= amount;
    }

    public void TakeCurrentAmmo(int amount)
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

    public void AddCurrentAmmo(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        CurrentAmmo += amount;
    }

    public void Reload()
    {
        _savedAmmo += CurrentAmmo;

        if (_savedAmmo >= _maxAmmo)
        {
            CurrentAmmo = _maxAmmo;
            _savedAmmo -= _maxAmmo;
        }
        else
        {
            CurrentAmmo = _savedAmmo;
            _savedAmmo = 0;
        }
    }
}
