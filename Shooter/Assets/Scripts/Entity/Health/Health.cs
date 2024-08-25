using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _currentHealth;

    [SerializeField, Min(0)] private int _startHealth;
    [SerializeField, Min(0)] private int _maxHealth;

    public int MaxHealth => _maxHealth;

    public int CurrentHealth
    {
        get { return _currentHealth; }
        private set { _currentHealth = Math.Clamp(value, 0, _maxHealth); }
    }

    public event Action HealthChanged;
    public event Action HealthOver;

    private void Start()
    {
        AddHealth(_startHealth);
        
        if (_currentHealth == 0)
        {
            HealthOver?.Invoke();
        }
    }

    public void AddHealth(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        CurrentHealth += amount;

        HealthChanged?.Invoke();
    }

    public void TakeHealth(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        CurrentHealth -= amount;

        HealthChanged?.Invoke();

        if (_currentHealth == 0)
        {
            HealthOver?.Invoke();
        }
    }
}