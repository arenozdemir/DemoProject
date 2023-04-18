using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierMovement : Leaf  
{
    Transform root;
    [SerializeField] List<Transform> points = new List<Transform>();
    private List<Vector3> vectors = new List<Vector3>();
    private bool isBeginned;
    private float pathResolution;
    Vector3 startPos;
    public override Status Process()
    {
        if (pathResolution >= 1) return Status.SUCCESS;
        Begin();
        float distance = Vector3.Distance(PathDrawer(pathResolution), PathDrawer(pathResolution + .1f));
        pathResolution += Time.deltaTime / (distance * 4f);
        root.position = PathDrawer(pathResolution);
        root.LookAt(PathDrawer(pathResolution + 0.01f));
        return Status.RUNNING;
    }
    private void OnDrawGizmos()
    {
        for(float i = 0; i < 30; i++)
        {
            Gizmos.DrawLine(PathDrawer(i/ (float)30), PathDrawer(i +1 / (float)30));
        }
    }
    private Vector3 PathDrawer(float t)
    {
        Vector3 a = Vector3.LerpUnclamped(startPos, points[0].position, t);
        Vector3 b = Vector3.LerpUnclamped(points[0].position, points[1].position, t);
        Vector3 c = Vector3.LerpUnclamped(points[1].position, points[2].position, t);
        Vector3 d = Vector3.LerpUnclamped(a, b, t);
        Vector3 e = Vector3.LerpUnclamped(b, c, t);

        return Vector3.LerpUnclamped(d, e, t);
    }

    private void Begin()
    {
        if (isBeginned) return;
        foreach (Transform point in points)
        {
            vectors.Add(point.position);
        }
        root = transform.root;
        startPos = root.position;
        animator.CrossFade("Walking", 0.1f);
        isBeginned = true;
    }
}
