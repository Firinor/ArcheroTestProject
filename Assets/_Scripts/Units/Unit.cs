using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class Unit : MonoBehaviour
{
    protected UnitBehaviorStateMachine behavior;
    protected UnitStats Stats;

    public Vector2 MovePoint { get; protected set; }
    public NavMeshAgent NavMeshAgent { get; private set; }

    public virtual void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SetBehavior(UnitBehavior newBehavior)
    {
        behavior.SetState(newBehavior, this);
    }
}
