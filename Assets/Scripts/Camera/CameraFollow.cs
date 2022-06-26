using UnityEngine;

public sealed class CameraFollow : MonoBehaviour
{
    const float smoothDampTime = 0.32f;
    private Vector3 currVelocity;
    public Vector3 offset = new Vector3(0, 0, -10);
    [SerializeField] private Transform target;

    private void OnEnable()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void LateUpdate()
    {
        if (target == null) return;
        Vector3 center = target.position;
        transform.position = Vector3.SmoothDamp(transform.position, center + offset, ref currVelocity, smoothDampTime);
    }
}
