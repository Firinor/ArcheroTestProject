
namespace EnemyBehaviorNamespace
{
    public class EnemyBehaviourStateMachine : UnitBehaviorStateMachine<EnemyBehavior, Enemy>
    {
        //public EnemyBehaviourStateMachine(EnemyBehavior startBehavior, Enemy enemy) : base(startBehavior, )
        //{
        //    currentBehaviour = startBehavior;
        //    unit = enemy;
        //    currentBehaviour.Enter(enemy);
        //}
        public EnemyBehaviourStateMachine(EnemyBehavior startBehavior, Enemy unit) : base(startBehavior, unit)
        {
        }
    }
}
