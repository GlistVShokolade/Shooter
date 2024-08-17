using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private int _startHealth;
    [SerializeField] private int _maxHealth;

    public int MaxHealth => _maxHealth;

    public int CurrentHealth
    {
        get
        {
            return CurrentHealth;
        }
        private set
        {
            CurrentHealth = Math.Clamp(value, 0, _maxHealth);
        }
    }

    public event Action HealthIsOver;
    public event Action HealthChanged;

    public void ApplyDamage(int damage)
    {
        if (damage < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(damage));
        }

        CurrentHealth -= damage;

        HealthChanged?.Invoke();

        if (CurrentHealth == 0)
        {
            HealthIsOver?.Invoke();
        }
    }
}
