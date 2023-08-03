public class UnitBehaviorStateMachine
{ 
    public UnitBehavior currentBehavior { get; private set; }

    public UnitBehaviorStateMachine(UnitBehavior startBehavior)
    {
        currentBehavior = startBehavior;
        currentBehavior.Enter();
    }

    public virtual void SetState(UnitBehavior newBehavior)
    {
        currentBehavior.Exit();
        currentBehavior = newBehavior;
        currentBehavior.Enter();
    }

    public virtual void Update()
    {
        currentBehavior.Update();
    }
}
