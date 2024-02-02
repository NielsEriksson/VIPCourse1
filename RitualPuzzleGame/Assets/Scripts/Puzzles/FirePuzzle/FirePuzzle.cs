using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePuzzle : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float moveSpeed = 5f;

    private Vector3[] trailPoints;

    private FireNode[] fireNodes;

    void Start()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();
        fireNodes = GetComponentsInChildren<FireNode>();
        trailPoints = new Vector3[fireNodes.Length];
        for (int i = 0; i < fireNodes.Length; i++)
        {
            trailPoints[i] = fireNodes[i].transform.position;
        }
    }

    void Update()
    {
        UpdateTrail();
    }

    void UpdateTrail()
    {
        // Set line positions
        lineRenderer.positionCount = trailPoints.Length;
        lineRenderer.SetPositions(trailPoints);
    }
}
