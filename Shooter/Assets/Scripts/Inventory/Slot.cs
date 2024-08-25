using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool IsAvailable { get; private set; } = false;

    [SerializeField] private Weapon _weapon;

    public Weapon Weapon => _weapon;

    public void GiveAcces()
    {
        IsAvailable = true;
    }

    public void TakeAcces()
    {
        IsAvailable = false;
    }
}