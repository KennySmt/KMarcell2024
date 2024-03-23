using UnityEngine;

public class ModifiedSpiralDrawer : SpiralDrawer
{
    [SerializeField] float positionMultiplier = 1.1f;
    protected override Vector3[] GetPositions()
    {
        Vector3[] points = base.GetPositions();

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = points[i] * positionMultiplier;
        }
        return points;
    }
}
