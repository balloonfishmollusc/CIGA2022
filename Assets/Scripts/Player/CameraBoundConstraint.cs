using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(64)]
public class CameraBoundConstraint : MonoBehaviour
{
    BoxCollider2D physicalCollider;

    private Vector3 previousPos;

    private void Awake()
    {
        physicalCollider = GetComponent<BoxCollider2D>();
    }

    private Bounds CalculateValidBounds()
    {
        Camera mainCamera = Camera.main;
        float vSize = mainCamera.orthographicSize * 2;
        float hSize = mainCamera.orthographicSize * Camera.main.aspect * 2;
        Vector2 boundsSize = new Vector2(hSize, vSize);

        boundsSize -= (Vector2)physicalCollider.bounds.size;
        return new Bounds((Vector2)mainCamera.transform.position, boundsSize);
    }

    private void LateUpdate()
    {
        Bounds bounds = CalculateValidBounds();
        
        if (!bounds.Contains(transform.position))
            transform.position = previousPos;

        previousPos = transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        Bounds bounds = CalculateValidBounds();
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}
