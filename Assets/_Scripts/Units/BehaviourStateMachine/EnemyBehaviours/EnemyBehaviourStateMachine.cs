
namespace EnemyBehaviorNamespace
{
    public class EnemyBehaviourStateMachine : UnitBehaviorStateMachine
    {
        public EnemyBehavior currentEnemyBehavior { get; private set; }
        protected Enemy enemy;

        public EnemyBehaviourStateMachine(EnemyBehavior startBehavior, Enemy enemy) : base(startBehavior)
        {
            currentEnemyBehavior = startBehavior;
            this.enemy = enemy;
        }
    }
}
