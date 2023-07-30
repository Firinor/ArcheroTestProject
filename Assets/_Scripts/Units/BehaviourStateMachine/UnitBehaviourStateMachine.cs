public class UnitBehaviorStateMachine
{ 
    public UnitBehavior currentBehavior { get; private set; }

    public UnitBehaviorStateMachine(UnitBehavior startBehavior, Unit unit)
    {
        currentBehavior = startBehavior;
        currentBehavior.Enter(unit);
    }

    public void SetState(UnitBehavior newBehavior, Unit unit)
    {
        currentBehavior.Exit();
        currentBehavior = newBehavior;
        currentBehavior.Enter(unit);
    }

    public void Update()
    {
        currentBehavior.Update();
    }
}
