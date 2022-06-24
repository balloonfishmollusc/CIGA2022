using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public float speed = 5f;

    public bool hasProp => transform.childCount == 1;

    public void Add(GameObject obj)
    {
        if (hasProp) return;
        obj.transform.parent = transform;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        obj.GetComponent<Rigidbody2D>().simulated = false;
    }

    public void Throw()
    {
        if (!hasProp) throw new System.Exception("没有东西可扔");
        var trans = transform.GetChild(0);
        trans.SetParent(null, true);

        var r2d = trans.GetComponent<Rigidbody2D>();
        if (r2d)
        {
            r2d.simulated = true;
            r2d.velocity = new Vector2(speed, 0);
        }
    }
}
