using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    public Health Health => _health;

    private void OnEnable()
    {
        _health.HealthChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateValue;
    }

    protected abstract void UpdateValue();
}
