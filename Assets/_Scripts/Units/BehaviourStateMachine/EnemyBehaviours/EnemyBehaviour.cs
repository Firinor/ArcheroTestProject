using System;

namespace EnemyBehaviorNamespace
{
    public abstract class EnemyBehavior : UnitBehaviour
    {
        public virtual void Enter(Enemy enemy) { }
        public virtual void Tick(Enemy enemy) { }
        public virtual void Exit(Enemy enemy) { }
    }
}
