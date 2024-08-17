using TMPro;
using UnityEngine;

public class HealthTextView : HealthView
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void UpdateValue()
    {
        _text.text = Health.CurrentHealth.ToString();
    }
}