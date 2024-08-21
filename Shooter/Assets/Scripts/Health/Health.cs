using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    private int _currentHealth;

    [SerializeField] private int _startHealth;
    [SerializeField] private int _maxHealth;

    public int MaxHealth => _maxHealth;

    public int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        private set
        {
            _currentHealth = Math.Clamp(value, 0, _maxHealth);
        }
    }

    public event Action HealthIsOver;
    public event Action HealthChanged;

    private void Start()
    {
        AddHealth(_startHealth);

        if (_currentHealth == 0)
        {
            HealthIsOver?.Invoke();
        }
    }

    public void ApplyDamage(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        CurrentHealth -= amount;

        HealthChanged?.Invoke();

        if (_currentHealth == 0)
        {
            HealthIsOver?.Invoke();
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
}
