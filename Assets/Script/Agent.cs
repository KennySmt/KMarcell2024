using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Agent : MonoBehaviour
{
    [SerializeField, HideInInspector] NavMeshAgent navMeshAgent;
    [SerializeField] float startHealth = 100;
    [SerializeField] int agentValue = 10;
    [SerializeField] int agentDamage = 10;
    [SerializeField] Elemental[] immunities;

    float health;

    public Action HealthChanged;

    public float HealthRate
    {
        get => health / startHealth;
        private set => health = value * startHealth;
    }
    

    void OnValidate()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        EndPoint ep = FindAnyObjectByType<EndPoint>();
        navMeshAgent.destination = ep.transform.position;
        HealthRate=1;
        HealthChanged?.Invoke();
    }

    public void OnHitEndPoint()
    {
        GameManager.instance.Damage(agentDamage);
        Destroy(gameObject);
    }
    /*
    public void Damage(float damage, string elemental) 
    {
        if (!immunities.Contains(elemental)) Damage(damage);
    }
    */
    internal void Damage(float damage,Elemental elemental = Elemental.Non)
    {
        if (elemental != Elemental.Non && immunities.Contains(elemental)) return;

        health -= damage;
        HealthChanged?.Invoke();
        if (health <= 0)
        {
            GameManager.instance.Money += agentValue;
            Destroy(gameObject);
        }
    }

    internal bool IsImmune(Elemental elemental)
    {
        return immunities.Contains(elemental);
    }
}
