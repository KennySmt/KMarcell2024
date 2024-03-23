using System;
using UnityEngine;

public abstract class Drawable : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;

    void OnValidate()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();
        UpdateLinePoint();
    }

    void Start()
    {
        UpdateLinePoint();
    }

    public void UpdateLinePoint()
    {
        if (lineRenderer == null) return;
        Vector3[] points = GetPositions();
        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
    }

    protected abstract Vector3[] GetPositions(); //protected -> leszármazottak hozzáférnek más nem/ abstrtact függvény csak abstract class ba lehet

    void OnDrawGizmosSelected()
    {
        Vector3[] points = GetPositions();
        for (int i = 0; i < points.Length - 1; i++)
        {
            int i2 = i + 1;
            Vector3 p1 = points[i];
            Vector3 p2 = points[i2];
            Gizmos.DrawLine(p1, p2);
        }
    }
}