using UnityEngine;

public abstract class UnitBehavior : ScriptableObject
{
    protected Unit unit;
    
    public virtual void Enter(Unit unit)
    {
        this.unit = unit;
    }
    public virtual void Update() { }
    public virtual void Exit() { }
}