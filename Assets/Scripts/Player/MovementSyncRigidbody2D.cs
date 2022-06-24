using UnityEngine;

[DisallowMultipleComponent()]
[DefaultExecutionOrder(64)]
public class MovementSyncRigidbody2D : MonoBehaviour
{
    private Rigidbody2D _targetRigidbody;
    public Rigidbody2D targetRigidbody
    {
        get { return _targetRigidbody; }
        set
        {
            if (value == _targetRigidbody) return;
            _targetRigidbody = value;
            if (_targetRigidbody != null)
                targetPrePos = targetPos = _targetRigidbody.position;
        }
    }

    public Rigidbody2D sourceRigidbody { get; set; }

    private void Start()
    {
        if (sourceRigidbody == null)
            sourceRigidbody = GetComponent<Rigidbody2D>();
    }

    [SerializeField] Vector2 scale = Vector2.one;
    private Vector2 targetPos;
    private Vector2 targetPrePos;

    private void FixedUpdate()
    {
        if (targetRigidbody != null)
        {
            targetPos = targetRigidbody.position;
            Vector2 change = targetPos - targetPrePos;
            sourceRigidbody.position += change * scale;
            targetPrePos = targetPos;
        }
    }
}

