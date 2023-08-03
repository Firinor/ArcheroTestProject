using UnityEngine;

public abstract class UnitBehavior : ScriptableObject
{
    protected Unit unit;
    
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}