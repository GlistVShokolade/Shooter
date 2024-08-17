using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character Instance;

    public CharacterInput Input { get; private set; }

    private void OnEnable()
    {
        if (Instance == null)
        {
            Input = new CharacterInput();
            Input.Enable();

            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        Input.Disable();
    }
}
