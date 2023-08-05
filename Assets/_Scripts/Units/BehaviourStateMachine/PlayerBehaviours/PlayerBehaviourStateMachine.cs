namespace PlayerBehaviourNamespace
{
    public class PlayerBehaviourStateMachine : UnitBehaviorStateMachine<PlayerBehavior, Player>
    {
        public PlayerBehaviourStateMachine(PlayerBehavior startBehavior, Player player) : base(startBehavior, player)
        {
        }
    }
}
