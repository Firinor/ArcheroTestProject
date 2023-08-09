using Damage;
using EnemyBehaviorNamespace;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class Enemy : Unit
{
    [Inject]
    private Level level;
    private Player player;

    [SerializeField]
    private EnemyBehavior startBehavior;
    [SerializeField]
    private UnitStats basisStats;
    private EnemyBehaviourStateMachine behavior;
    [SerializeField]
    private Transform bulletSpawnPoint;

    [SerializeField]
    private CurrentStats currentStats;

    private CompositeDisposable disposables = new CompositeDisposable();

    public Vector3 Target => player.transform.position;

    public bool IsAlive => currentStats.Helth <= 0;

    public override void Awake()
    {
        base.Awake();
        behavior = new EnemyBehaviourStateMachine(startBehavior, this);
        currentStats = new CurrentStats()
        {
            Helth = basisStats.Health,
            Cooldown = 0
        };
        NavMeshAgent.speed = basisStats.Speed;

        FindEnemy();

        Observable.EveryFixedUpdate()
            .Where(_ => currentStats.Cooldown > 0)
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

    private void FindEnemy()
    {
        player = level.Player;
    }
    private void Cooldown()
    {
        currentStats.Cooldown -= Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            Attack(player);
    }

    public void Attack(Player player)
    {
        if (currentStats.Cooldown <= 0)
        {
            currentStats.Cooldown += basisStats.AttackRate;
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
                new KeyValuePair<Stat, Type>( Stat.SpawnPosition, typeof(Vector3) ), bulletSpawnPoint
            },
            {
                new KeyValuePair<Stat, Type>( Stat.Target, typeof(Vector3) ), Target
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
        public float Cooldown;
    }
}
