using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    private int _currentHealth;

    [SerializeField] private int _startHealth;
    [SerializeField] private int _maxHealth;

    public int MaxHealth => _maxHealth;
    public bool IsAlive => _currentHealth > 0f;

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
        CurrentHealth += _startHealth;

        if (IsAlive == false)
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

        if (IsAlive == false)
        {
            HealthIsOver?.Invoke();
        }
        else
        {
            HealthChanged?.Invoke();
        }

        print(CurrentHealth);
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
