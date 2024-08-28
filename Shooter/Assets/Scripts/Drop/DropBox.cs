using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropBox : MonoBehaviour
{
    [SerializeField] private Health _health;
    [Space]
    [SerializeField] private Transform _dropSpawnpoint;
    [SerializeField] private Drop[] _drop;
    [Space]
    [SerializeField] private bool _useRandom;
    [SerializeField, Min(1)] private int _spawnSteps;

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
        int index = 0;

        for (int i = 0; i < _spawnSteps; i++)
        {
            index = Math.Clamp(i, 0, _drop.Length - 1);

            if (_useRandom)
            {
                index = Random.Range(0, _drop.Length);
            }

            Instantiate(_drop[index], _dropSpawnpoint.position, Quaternion.identity);
        }
    }
}
