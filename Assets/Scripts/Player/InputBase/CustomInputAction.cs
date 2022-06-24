using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public abstract class CustomInputAction
{
    [SerializeField] protected InputAction action;

    public bool enabled => action.enabled;
    public bool initialized { get; private set; } = false;

    protected abstract void Initialize();

    public void Enable()
    {
        if (!initialized)
        {
            Initialize();
            initialized = true;
        }

        action.Enable();
    }

    public void Disable()
    {
        action.Disable();
    }
}
