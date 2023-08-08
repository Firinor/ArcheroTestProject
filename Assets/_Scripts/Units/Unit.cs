using Damage;
using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public abstract class Unit : MonoBehaviour
{
    protected UnitStats Stats;
    [SerializeField]
    protected Weapon weapon;
    [Inject]
    protected PackerService packer;

    public Action<Unit> OnDeath;
    public Vector2 MovePoint { get; protected set; }
    public NavMeshAgent NavMeshAgent { get; private set; }

    public virtual void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Death()
    {
        OnDeath?.Invoke(this);
        NavMeshAgent.enabled = false;
        Destroy(gameObject);
    }

    public virtual void TakeHit(AttackData attackData)
    {
        
    }
}
