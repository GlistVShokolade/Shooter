using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected Health Health => _health;

    private void OnEnable()
    {
        _health.HealthChanged += UpdateView;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateView;
    }

    protected abstract void UpdateView();
}