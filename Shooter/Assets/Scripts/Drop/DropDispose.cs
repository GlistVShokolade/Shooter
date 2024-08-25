using UnityEngine;

public class DropDispose : MonoBehaviour
{
    [SerializeField] private Drop _drop;

    private void OnEnable()
    {
        _drop.DropPicked += OnDispose;
    }

    private void OnDisable()
    {
        _drop.DropPicked -= OnDispose;
    }

    private void OnDispose()
    {
        Destroy(_drop.gameObject);
    }
}