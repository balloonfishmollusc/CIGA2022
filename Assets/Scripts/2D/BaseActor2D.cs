using UnityEngine;

public abstract class BaseActor2D : MonoBehaviour
{
    public abstract Vector2 position { get; set; }
    public abstract Vector2 velocity { get; set; }

    public event System.Action onUpdate;
    public event System.Action onFixedUpdate;

    protected virtual void Update()
    {
        onUpdate?.Invoke();
    }

    protected virtual void FixedUpdate()
    {
        onFixedUpdate?.Invoke();
    }
}
