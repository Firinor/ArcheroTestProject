using UnityEngine;

namespace EnemyBehaviorNamespace
{
    [CreateAssetMenu(fileName = "EnemyMoveUnitBehavior", menuName = "GameScriptable/UnitBehaviors/EnemyMoveUnitBehavior")]
    public class Move : EnemyBehavior
    {
        public override void Tick(Enemy enemy)
        {
            enemy.NavMeshAgent.SetDestination(enemy.Target);
        }
    }
}