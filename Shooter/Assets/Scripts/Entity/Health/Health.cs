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

    public bool IsDied => _currentHealth == 0;
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

    public void AddHealth(int amount)
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

    public void TakeHealth(int amount)
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

        HealthChanged?.Invoke();

        if (IsDied)
        {
            HealthOver?.Invoke();
        }
    }
}