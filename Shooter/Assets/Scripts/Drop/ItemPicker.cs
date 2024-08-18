using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDrop drop))
        {
            drop.Pick();
        }
    }
}
