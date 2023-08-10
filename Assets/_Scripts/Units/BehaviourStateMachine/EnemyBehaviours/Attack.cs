using UnityEngine;

namespace EnemyBehaviourNamespace
{
    [CreateAssetMenu(fileName = "AttackUnitBehavior", menuName = "GameScriptable/UnitBehaviors/EnemyAttackBehavior")]
    public class Attack : EnemyBehavior
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private EnemyBehavior idle;
        [SerializeField]
        private EnemyBehavior move;

        public override void Tick(Enemy unit)
        {
            if (!unit.IsPlayerInSight())
            {
                unit.SetBehavior(move);
                return;
            }
                

            if (!unit.IsPlayerAlive())
            {
                unit.SetBehavior(idle);
                return;
            }

            unit.LookAtPlayer();
            unit.Attack();
        }
    }
}

