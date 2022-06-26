using UnityEngine;
using UnityEngine.UI;

public class CameraFollowButton : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponentInChildren<Toggle>().isOn = Camera.main.GetComponent<CameraFollow>().enabled;
    }
}
