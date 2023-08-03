using System;

namespace EnemyBehaviorNamespace
{
    public abstract class EnemyBehavior : UnitBehavior
    {
        public virtual void Enter(Enemy enemy) { }
        public virtual void Tick(Enemy enemy) { }
        public virtual void Exit(Enemy enemy) { }
    }
}
