using TMPro;
using UnityEngine;

public class AmmoTextView : AmmoView
{
    [SerializeField] private TextMeshProUGUI _view;

    protected override void UpdateView()
    {
        _view.text = Ammo.CurrentAmmo.ToString();
    }
}