using System;
using UnityEngine;

public class SpiralDrawer : Drawable
{
    [SerializeField] Vector3 center;
    [SerializeField] float radius = 1;
    [SerializeField, Min(3)] int pointCount = 100;
    [SerializeField] float height;
    [SerializeField] float cycles = 10;

    protected override Vector3[] GetPositions() //overrideolni kell szülõbe definiált abstract függvényt/lehetõség van overrideolni virtual függvényt, ha nem akkor a szülõbe lévõt használja
    {
        Vector3[] result = new Vector3[pointCount];

        float deltaAngle = cycles * 2 * MathF.PI / (pointCount - 1);
        Vector3 offset = Vector3.forward * height / (pointCount - 1);

        for (int i = 0; i < pointCount; i++)
        {
            float angle = ((i) % pointCount) * deltaAngle;
            result[i] = GetPoint(angle) + (offset * i);
        }
        return result;
    }

    Vector3 GetPoint(float angle)
    {
        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);
        return (new Vector3(x, y) * radius) + center;
    }
}
