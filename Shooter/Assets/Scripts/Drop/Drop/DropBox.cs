using UnityEngine;

[RequireComponent (typeof(Health))]
public class DropBox : MonoBehaviour
{
    [SerializeField] private Health _health;
    [Space]
    [SerializeField] private Drop[] _drop;

    private void OnEnable()
    {
        _health.HealthIsOver += OnBreak;
    }

    private void OnDisable()
    {
        _health.HealthIsOver -= OnBreak;
    }

    private void OnBreak()
    {
        foreach (var drop in _drop)
        {
            Instantiate(drop, _health.transform.position, Quaternion.identity);
        }

        Destroy(_health.gameObject);
    }
}
