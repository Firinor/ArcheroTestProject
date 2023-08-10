using UnityEngine;
using Zenject;

namespace EnemyBehaviourNamespace
{
    [CreateAssetMenu(fileName = "EnemyIdleUnitBehavior", menuName = "GameScriptable/UnitBehaviors/EnemyIdleUnitBehavior")]
    public class Idle : EnemyBehavior
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private EnemyBehavior attack;

        public override void Tick(Enemy unit)
        {
            if (unit.IsPlayerAlive())
            {
                unit.SetBehavior(attack);
                return;
            }
        }
    }
}