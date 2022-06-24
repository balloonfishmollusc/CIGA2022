using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-32)]    // We need this to ensure `isGrounded` is updated before it is used
public class GroundDetector : MonoBehaviour
{
    public LayerMask whatIsGround = -1;

    public HashSet<Collider2D> hittings = new HashSet<Collider2D>();
    public bool isGrounded => hittings.Count > 0;

    private BoxCollider2D b2d;

    private void Awake()
    {
        b2d = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        ContactFilter2D filter2D = new ContactFilter2D();
        filter2D.SetLayerMask(whatIsGround);
        List<Collider2D> results = new List<Collider2D>();
        int count = b2d.OverlapCollider(filter2D, results);

        hittings.Clear();
        for (int i = 0; i < count; i++)
        {
            if (results[i].attachedRigidbody == b2d.attachedRigidbody)
                continue;

            if (!results[i].isTrigger)
                hittings.Add(results[i]);
        }
    }
}
