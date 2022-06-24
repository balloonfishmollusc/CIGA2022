using UnityEngine;
using System.Collections;

[DisallowMultipleComponent()]
public class MovementSync : MonoBehaviour
{
    private Transform _targetTransform;
    public Transform targetTransform
    {
        get { return _targetTransform; }
        set
        {
            if (value == _targetTransform) return;
            _targetTransform = value;
            if (_targetTransform != null)
                targetPrePos = targetPos = _targetTransform.position;
        }
    }

    public Transform sourceTransform { get; set; }

    private void Start()
    {
        if (sourceTransform == null)
            sourceTransform = transform;
    }

    [SerializeField] Vector2 scale = Vector2.one;
    private Vector2 targetPos;
    private Vector2 targetPrePos;

    private void LateUpdate()
    {
        if (targetTransform != null)
        {
            targetPos = targetTransform.position;
            Vector2 change = targetPos - targetPrePos;
            sourceTransform.position += (Vector3)(change * scale);
            targetPrePos = targetPos;
        }
    }
}
