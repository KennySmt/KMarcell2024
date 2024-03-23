using UnityEngine;

public class RangedTargetProvider : TargetProvider
{
    [SerializeField] float range = 2;

    Agent target;

    public override Agent GetTarget()
    {   
        if (target != null && !IsInRange(target))
            target = null;

        if (target == null)
            target = FindClosestAgentInRange();
        return target;
    }

    private Agent FindClosestAgentInRange()
    {
        Agent[] allAgents = FindObjectsOfType<Agent>();

        Agent closest = null;
        float closestDistance = float.MaxValue;
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        if (target != null)
            Gizmos.DrawLine(target.transform.position, transform.position);
    }
}
