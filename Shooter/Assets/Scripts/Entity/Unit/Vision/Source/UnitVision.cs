using System;
using UnityEngine;

public class UnitVision : MonoBehaviour
{
    public event Action<Player> PlayerDetected;
    public event Action<Player> PlayerLosted;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player) == false)
        {
            return;
        }

        OnDetect();

        PlayerDetected?.Invoke(player);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player) == false)
        {
            return;
        }

        OnLost();

        PlayerLosted?.Invoke(player);
    }

    protected virtual void OnLost() { }
    protected virtual void OnDetect() { }
}