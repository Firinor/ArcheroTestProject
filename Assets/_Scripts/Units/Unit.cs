using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class Unit : MonoBehaviour
{
    protected UnitStats Stats;

    public Action<Unit> OnDeath;
    public Vector2 MovePoint { get; protected set; }
    public NavMeshAgent NavMeshAgent { get; private set; }

    public virtual void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    public virtual void SetBehavior<TBehaviour>(TBehaviour newBehavior) where TBehaviour : UnitBehaviour
    {
    }

    protected virtual void Death()
    {
        OnDeath?.Invoke(this);
        NavMeshAgent.enabled = false;
        Destroy(gameObject);
    }

    public virtual void Damage(float damage)
    {
        
    }
}
