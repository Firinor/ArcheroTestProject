namespace PlayerBehaviourNamespace
{
    public class PlayerBehaviourStateMachine : UnitBehaviorStateMachine
    {
        public PlayerBehavior currentPlayerBehavior { get; private set; }
        protected Player player;

        public PlayerBehaviourStateMachine(PlayerBehavior startBehavior, Player player) : base(startBehavior)
        {
            currentPlayerBehavior = startBehavior;
            this.player = player;
            currentPlayerBehavior.Enter(player);
        }

        public virtual void SetState(PlayerBehavior newPlayerBehavior)
        {
            currentPlayerBehavior.Exit(player);
            currentPlayerBehavior = newPlayerBehavior;
            currentPlayerBehavior.Enter(player);
        }

        public override void Tick()
        {
            currentPlayerBehavior.Tick(player);
        }
    }
}
