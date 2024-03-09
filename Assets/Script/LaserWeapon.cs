
using System;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    [SerializeField] float range = 2;
    [SerializeField] float damageRate = 10;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField, Min(2)] int laserPointCount = 10;

    Agent closest = null;

    void Update()
    {
        if (closest != null && !IsInRange(closest))
            closest = null;

        if (closest == null)
            closest = FindClosestAgentInRange();

        if (closest != null)
            closest.Damage(damageRate * Time.deltaTime);

        UpdateLaserVisual();
    }

    private Agent FindClosestAgentInRange()
    {
        Agent[] allAgents = FindObjectsOfType<Agent>();

        Agent closest = null;
        float closestDistance =float.MaxValue;
        Vector3 p = transform.position;

        foreach (Agent agent in allAgents) 
        {
            float distance = Vector3.Distance(agent.transform.position, p);
            if (distance > range) continue;
            if (distance > closestDistance) continue;

            closest = agent;
            closestDistance = distance;
        }

        return closest;
    }
    private bool IsInRange(Agent agent)
    {
        Vector3 p = transform.position;
        float distance = Vector3.Distance(agent.transform.position, p);
        return distance <= range;
    }
    void UpdateLaserVisual()
    {
        lineRenderer.enabled = closest != null;
        if (closest == null) return;

        lineRenderer.positionCount = 2;
        /*
        lineRenderer.positionCount = laserPointCount;
        for (int i = 0; i < laserPointCount; i++)
        {
            lineRenderer.SetPosition(i, Vector3.Lerp(transform.position, closest.transform.position, 1f/ (float)laserPointCount-i));
        }
        */
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, closest.transform.position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        if (closest != null)
            Gizmos.DrawLine(closest.transform.position, transform.position);
    }
}
