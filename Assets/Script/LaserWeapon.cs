
using System;
using UnityEngine;

public class LaserWeapon : Weapon
{
    
    [SerializeField] float damageRate = 10;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField, Min(2)] int laserPointCount = 10;



    protected override void ChildUpdate()
    {
        if (Target != null)
            Target.Damage(damageRate * Time.deltaTime);

        UpdateLaserVisual();
    }

    
    void UpdateLaserVisual()
    {
        lineRenderer.enabled = Target != null;
        if (Target == null) return;

        lineRenderer.positionCount = 2;
        /*
        lineRenderer.positionCount = laserPointCount;
        for (int i = 0; i < laserPointCount; i++)
        {
            lineRenderer.SetPosition(i, Vector3.Lerp(transform.position, closest.transform.position, 1f/ (float)laserPointCount-i));
        }
        */
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, Target.transform.position);
    }
}
