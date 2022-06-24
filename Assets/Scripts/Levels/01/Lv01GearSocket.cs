using UnityEngine;
using GameFlow;

public class Lv01GearSocket : InteractiveBehaviour
{
    public GameObject topGear;

    [SlotMethod("prop/settings/enter")]
    void OnSignal(Signal s)
    {
        var obj = s.source.gameObject;
        obj.transform.SetParent(transform);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;

        obj.GetComponent<Rotation>().enabled = true;
        obj.GetComponent<Rigidbody2D>().simulated = false;
        topGear.GetComponent<Rotation>().enabled = true;
    }
}
