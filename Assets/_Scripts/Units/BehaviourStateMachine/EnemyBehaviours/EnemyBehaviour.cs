using System;

namespace EnemyBehavior
{
    public abstract class EnemyBehavior : UnitBehavior
    {
        protected Enemy enemy;

        public override void Enter(Unit unit)
        {
            if (unit is Enemy enemy)
                this.enemy = enemy;
            else
                throw new Exception("The behavior is designed to work with units of the Enemy type!");
        }
    }
}
