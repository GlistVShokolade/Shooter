using UnityEngine;

public class DropPicker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDrop drop) == false)
        {
            return;
        }

        drop.TryPick();
    }
}
