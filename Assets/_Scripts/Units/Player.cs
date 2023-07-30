using System;
using UnityEngine;
using Zenject;

public class Player : Unit
{
    [Inject]
    private VisibleFloatingJoystick joystick;
    [SerializeField]
    private UnitBehavior startBehavior;
    [Inject(Id = "Player")]
    private UnitStats basisStats;
    private CurrentStats currentStats;

    private Enemy[] enemies;

    public override void Awake()
    {
        base.Awake();
        behavior = new UnitBehaviorStateMachine(startBehavior, this);
    }

    internal void Attack()
    {
        //bulletFactory.Create(this);
        currentStats.Cooldown += basisStats.AttackRate;
    }

    internal bool IsReadyToAttack()
    {
        return currentStats.Cooldown <= 0
            && EnemyIsInSight();
    }

    private bool EnemyIsInSight()
    {
        throw new NotImplementedException();
    }

    internal void LookAtEnemy()
    {
        transform.LookAt(currentStats.target.transform);
    }

    private void FixedUpdate()
    {
        MovePoint = joystick.Direction;
        behavior.Update();
    }

    public bool IsJoystickDirection()
    {
        return joystick.Direction.x != 0 || joystick.Direction.y != 0;
    }

    private class CurrentStats
    {
        public int Helth;
        public float Cooldown;
        public Enemy target;
    }
}
