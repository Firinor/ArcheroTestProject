using System;

namespace PlayerBehaviourNamespace
{
    public abstract class PlayerBehavior : UnitBehaviour<Player>
    {
        public override void Enter(Player player) { }
        public override void Tick(Player player) { }
        public override void Exit(Player player) { }
    }
}
