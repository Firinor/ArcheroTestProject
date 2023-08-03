using EnemyBehaviorNamespace;
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
    [Inject(Id = "MeleeEnemy")]
    private UnitStats basisStats;
    private EnemyBehaviourStateMachine behavior;

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
            player.Attack();
    }

    public void Attack()
    {
        if (currentStats.Cooldown <= 0)
        {
            currentStats.Cooldown += basisStats.AttackRate;
            player.Damage(basisStats.Damage);
        }
    }

    public override void Damage(float damage)
    {
        currentStats.Helth -= (int)damage;
        if (currentStats.Helth <= 0)
            Death();
    }

    protected override void Death()
    {

        base.Death();
    }

    private class CurrentStats
    {
        public int Helth;
        public float Cooldown;
    }
}
