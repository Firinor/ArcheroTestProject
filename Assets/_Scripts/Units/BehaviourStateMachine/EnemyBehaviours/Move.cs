using UnityEngine;

namespace EnemyBehavior
{
    [CreateAssetMenu(fileName = "EnemyMoveUnitBehavior", menuName = "GameScriptable/UnitBehaviors/EnemyMoveUnitBehavior")]
    public class Move : EnemyBehavior
    {
        public override void Update()
        {
            enemy.NavMeshAgent.SetDestination(enemy.Target);
        }
    }
}