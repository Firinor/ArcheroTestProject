using System;

namespace PlayerBehavior
{
    public abstract class PlayerBehavior : UnitBehavior
    {
        protected Player player;

        public override void Enter(Unit unit)
        {
            if (unit is Player player)
                this.player = player;
            else
                throw new Exception("The behavior is designed to work with units of the Player type!");
        }
    }
}
