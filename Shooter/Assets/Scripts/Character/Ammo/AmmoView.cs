using UnityEngine;

public abstract class AmmoView : MonoBehaviour
{
    [SerializeField] private Ammo _ammo;

    protected Ammo Ammo => _ammo;

    private void OnEnable()
    {
        _ammo.AmmoChanged += UpdateView;
    }

    private void OnDisable()
    {
        _ammo.AmmoChanged -= UpdateView;
    }

    protected abstract void UpdateView();
}
