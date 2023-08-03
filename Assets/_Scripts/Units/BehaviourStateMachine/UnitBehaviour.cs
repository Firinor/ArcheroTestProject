using UnityEngine;

public abstract class UnitBehaviour : ScriptableObject
{ 
    public virtual void Enter(Unit unit) { }
    public virtual void Tick(Unit unit) { }
    public virtual void Exit(Unit unit) { }
}