﻿
namespace EnemyBehaviorNamespace
{
    public class EnemyBehaviourStateMachine : UnitBehaviorStateMachine<EnemyBehavior, Enemy>
    {
        public EnemyBehaviourStateMachine(EnemyBehavior startBehavior, Enemy unit) : base(startBehavior, unit)
        {
        }
    }
}
