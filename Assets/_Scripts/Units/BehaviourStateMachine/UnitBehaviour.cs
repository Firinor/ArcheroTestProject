using UnityEngine;

public abstract class UnitBehavior : ScriptableObject
{ 
    public virtual void Enter() { }
    public virtual void Tick() { }
    public virtual void Exit() { }
}