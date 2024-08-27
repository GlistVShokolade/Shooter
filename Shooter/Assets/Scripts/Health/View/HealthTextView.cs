using TMPro;
using UnityEngine;

public class HealthTextView : HealthView
{
    [SerializeField] private TextMeshProUGUI _view;

    protected override void UpdateView()
    {
        _view.text = Health.CurrentHealth.ToString();
    }
}