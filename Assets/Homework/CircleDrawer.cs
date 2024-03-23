using System;
using UnityEngine;

public class CircleDrawer : Drawable
{
    [SerializeField] Vector3 center;
    [SerializeField] float radius = 1;
    [SerializeField, Min(3)] int pointCount = 100;


    protected override Vector3[] GetPositions()
    {
        Vector3[] restult = new Vector3[pointCount];
        float deltaAngle = 2 * MathF.PI / (pointCount-1);

        for (int i = 0; i < pointCount; i++)
        {
            float angle = ((i) % pointCount) * deltaAngle;
            restult[i] = GetPoint(angle);
        }
        return restult;
    }

    Vector3 GetPoint(float angle)
    {
        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);
        return (new Vector3(x,y) * radius) + center;
    }
}
