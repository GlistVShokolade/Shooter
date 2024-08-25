using UnityEngine;

public class DropPicker : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Drop drop) == false)
        {
            return;
        }

        drop.TryPick(_player);
    }
}
