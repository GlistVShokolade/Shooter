using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private int _savedAmmo;
    private int _currentAmmo;

    [Header("Ammo")]
    [SerializeField] private int _startAmmo;
    [SerializeField] private int _maxAmmo;
    [Space]
    [SerializeField] private AmmoType _type;

    public int MaxAmmo => _maxAmmo;
    public int SavedAmmo => _savedAmmo;
    public AmmoType Type => _type;

    public int CurrentAmmo
    {
        get { return _currentAmmo; }
        private set { _currentAmmo = Math.Clamp(value, 0, _maxAmmo); }
    }

    public event Action AmmoChanged;

    private void Start()
    {
        CurrentAmmo = _startAmmo;

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

    public void AddAmmo(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        _savedAmmo += amount;

        AmmoChanged?.Invoke();
    }
}
