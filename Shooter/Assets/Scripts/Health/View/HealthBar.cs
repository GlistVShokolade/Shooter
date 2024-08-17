using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HealthView
{
    [SerializeField] private Slider _bar;
    [SerializeField] private Gradient _gradient;

    protected override void UpdateValue()
    {
        _bar.image.color = _gradient.Evaluate(Health.CurrentHealth / Health.MaxHealth);
    }
}
