using UnityEngine;
using UnityEngine.Events;

public class Activatable : MonoBehaviour
{
    public UnityEvent on;
    public UnityEvent off;

    private void OnEnable()
    {
        on.Invoke();
    }

    private void OnDisable()
    {
        off.Invoke();
    }
}
