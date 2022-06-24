using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class RigidbodyActor2D : BaseActor2D
{
    public Rigidbody2D r2d { get; private set; }

    protected virtual void Awake()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    public override Vector2 position {
        get { return r2d.position; }
        set { r2d.position = value; }
    }

    public override Vector2 velocity {
        get { return r2d.velocity; }
        set { r2d.velocity = value; }
    }

    protected virtual void OnEnable()
    {
        r2d.simulated = true;
    }

    protected virtual void OnDisable()
    {
        r2d.simulated = false;
    }
}
