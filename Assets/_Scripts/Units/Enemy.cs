using Damage;
using EnemyBehaviourNamespace;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class Enemy : Unit
{
    [Inject]
    private Level level;
    private Player player => level.Player;
    public Vector3 Target => player.transform.position;

    [SerializeField]
    private EnemyBehavior startBehavior;
    private EnemyBehaviourStateMachine behavior;

    [SerializeField]
    private UnitStats basisStats;
    private CurrentStats currentStats;

    [SerializeField]
    private Transform bulletSpawnPoint;

    private CompositeDisposable disposables = new CompositeDisposable();

    public bool IsAlive => currentStats.Helth <= 0;

    public override void Awake()
    {
        base.Awake();
        behavior = new EnemyBehaviourStateMachine(startBehavior, this);
        currentStats = new CurrentStats()
        {
            Helth = basisStats.Health,
        };
        NavMeshAgent.speed = basisStats.Speed;

        Observable.EveryFixedUpdate()
            .Where(_ => !weapon.isReady)
            .Subscribe(_ => Cooldown())
            .AddTo(disposables);
    }


    private void FixedUpdate()
    {
        behavior.Tick();
    }

    public void SetBehavior(EnemyBehavior newBehavior)
    {
        behavior.SetState(newBehavior);
    }

    private void Cooldown()
    {
        weapon.CooldownTick(Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            Attack();
    }

    public void LookAtPlayer()
    {
        transform.LookAt(Target);
    }

    public bool IsPlayerAlive()
    {
        if (player == null)
            return false;

        return player.IsAlive;
    }

    public bool IsPlayerInSight()
    {
        Ray ray = new Ray(bulletSpawnPoint.position, DirectionTo(Target));

        LayerMask mask = new LayerMask();
        mask.value = LayerMask.GetMask(basisStats.EnemyLayer) + LayerMask.GetMask("Ground");

        if (!Physics.Raycast(ray, out RaycastHit hit, maxDistance: int.MaxValue, layerMask: mask))
            return false;

        if (hit.collider.tag == basisStats.EnemyTag)
            return true;

        return false;

        Vector3 DirectionTo(Vector3 target)
        {
            return target - bulletSpawnPoint.position;
        }
    }

    public void Attack()
    {
        if (IsPlayerInSight())
        {
            weapon.Attack(GenerateAttackData());
        }
    }

    private AttackData GenerateAttackData()
    {
        AttackContainer data = new AttackContainer() 
        {
            {
                new KeyValuePair<Stat, Type>( Stat.Damage, typeof(float) ), basisStats.Damage 
            },
            {
                new KeyValuePair<Stat, Type>( Stat.AttackRate, typeof(float) ), basisStats.AttackRate
            },
            {
                new KeyValuePair<Stat, Type>( Stat.SpawnPosition, typeof(Vector3) ), bulletSpawnPoint.position
            },
            {
                new KeyValuePair<Stat, Type>( Stat.Target, typeof(Vector3) ), Target
            },
            {
                new KeyValuePair<Stat, Type>( Stat.Target, typeof(Unit) ), player
            },
            {
                new KeyValuePair<Stat, Type>( Stat.Filter, typeof(string[]) ), new string[]{ basisStats.EnemyTag , "Ground"}
            },
        };

        return new AttackData(data);
    }

    public override void TakeHit(AttackData attackData)
    {
        float damage = packer.GetParameter<float>(Stat.Damage, attackData);
        currentStats.Helth -= damage;
        if (currentStats.Helth <= 0)
            Death();
    }

    protected override void Death()
    {

        base.Death();
    }

    private class CurrentStats
    {
        public float Helth;
    }
}
