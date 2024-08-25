using UnityEngine;

public class DropBox : MonoBehaviour
{
    [SerializeField] private Health _health;
    [Space]
    [SerializeField] private Transform _dropSpawnpoint;
    [SerializeField] private Drop[] _drop;

    private void OnEnable()
    {
        _health.HealthOver += SpawnDrop;
    }

    private void OnDisable()
    {
        _health.HealthOver += SpawnDrop;
    }

    private void SpawnDrop()
    {
        foreach (var drop in _drop)
        {
            Instantiate(drop, _dropSpawnpoint.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
