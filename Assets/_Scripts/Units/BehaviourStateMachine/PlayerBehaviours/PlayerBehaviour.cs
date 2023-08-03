using System;

namespace PlayerBehaviourNamespace
{
    public abstract class PlayerBehavior : UnitBehavior
    {
        public virtual void Enter(Player player) { }
        public virtual void Tick(Player player) { }
        public virtual void Exit(Player player) { }
    }
}
