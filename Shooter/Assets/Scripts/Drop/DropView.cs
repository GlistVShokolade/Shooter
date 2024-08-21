using UnityEngine;

public class DropView : MonoBehaviour
{
    [SerializeField] private Drop _drop;

    private void OnEnable()
    {
        _drop.DropPicked += OnPick;
    }

    private void OnDisable()
    {
        _drop.DropPicked -= OnPick;
    }

    private void OnPick()
    {
        Destroy(_drop.gameObject);

        if (_drop.gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}