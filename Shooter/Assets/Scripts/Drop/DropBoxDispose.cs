using UnityEngine;

public class DropBoxDispose : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.HealthOver += OnDispose;
    }

    private void OnDisable()
    {
        _health.HealthOver += OnDispose;
    }

    private void OnDispose()
    {
        Destroy(gameObject);
    }
}
