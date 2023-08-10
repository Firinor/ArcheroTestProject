using UnityEngine;

namespace EnemyBehaviourNamespace
{
    [CreateAssetMenu(fileName = "RangedMove", menuName = "GameScriptable/UnitBehaviors/RangedMove")]
    public class RangedMove : EnemyBehavior
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private EnemyBehavior attack;
        [SerializeField]
        private EnemyBehavior idle;

        public override void Tick(Enemy unit)
        {
            if (!unit.IsPlayerAlive())
            {
                unit.SetBehavior(idle);
                return;
            }

            if (unit.IsPlayerInSight())
            {
                unit.SetBehavior(attack);
                return;
            }

            unit.NavMeshAgent.SetDestination(unit.Target);
        }

        public override void Exit(Enemy unit)
        {
            unit.NavMeshAgent.SetDestination(unit.transform.position);
        }
    }
}