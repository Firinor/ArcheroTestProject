public class UnitBehaviorStateMachine
{
    public UnitBehaviorStateMachine(UnitBehavior startBehavior, Unit unit)
    {
        currentBehavior = startBehavior;
        currentBehavior.Enter(unit);
    }

    public UnitBehavior currentBehavior { get; private set; }

    public void SetState(UnitBehavior newBehavior, Unit unit = null)
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
