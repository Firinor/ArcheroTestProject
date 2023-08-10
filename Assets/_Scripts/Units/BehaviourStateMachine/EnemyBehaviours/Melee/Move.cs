using UnityEngine;

namespace EnemyBehaviourNamespace
{
    [CreateAssetMenu(fileName = "EnemyMoveUnitBehavior", menuName = "GameScriptable/UnitBehaviors/EnemyMoveUnitBehavior")]
    public class Move : EnemyBehavior
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private EnemyBehavior idle;

        public override void Tick(Enemy unit)
        {
            if (!unit.IsPlayerAlive())
            {
                unit.SetBehavior(idle);
                return;
            }

            unit.NavMeshAgent.SetDestination(unit.Target);
        }
    }
}