using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField]
    protected UnitStats Stats;

    protected UnitBehavior behavior;
    public Vector2 MoveVector { get; protected set; }
    public Transform target { get; protected set; }
    public NavMeshAgent NavMeshAgent { get; private set; }

    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }
}
