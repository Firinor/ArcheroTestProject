using System;

namespace EnemyBehaviorNamespace
{
    public abstract class EnemyBehavior : UnitBehaviour<Enemy>
    {
        public override void Enter(Enemy enemy) { }
        public override void Tick(Enemy enemy) { }
        public override void Exit(Enemy enemy) { }
    }
}
