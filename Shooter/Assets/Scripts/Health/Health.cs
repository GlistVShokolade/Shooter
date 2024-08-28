using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _currentHealth;

    [SerializeField, Min(0f)] private float _startHealth;
    [SerializeField, Min(0f)] private float _maxHealth;

    public float CurrentHealth
    {
        get { return _currentHealth; }
        private set { _currentHealth = Math.Clamp(value, 0, _maxHealth); }
    }

    public float MaxHealth => _maxHealth;

    public bool IsDied => _currentHealth == 0f;
    public bool IsFull => _currentHealth == _maxHealth;

    public event Action HealthChanged;
    public event Action HealthOver;

    private void Start()
    {
        CurrentHealth += _startHealth;
        
        if (IsDied)
        {
            HealthOver?.Invoke();
        }
    }

    public void AddHealth(float amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }
        if (IsDied)
        {
            return;
        }

        CurrentHealth += amount;

        HealthChanged?.Invoke();
    }

    public void TakeHealth(float amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }
        if (IsDied)
        {
            return;
        }

        CurrentHealth -= amount;

        if (IsDied)
        {
            HealthOver?.Invoke();
        }
        else
        {
            HealthChanged?.Invoke();
        }
    }
}