using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character Instance;

    [field: SerializeField] public Camera Camera { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }

    public CharacterInput Input { get; private set; }

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Input = new CharacterInput();
        Input.Enable();
    }

    private void OnDisable()
    {
        Input.Disable();
    }
}
