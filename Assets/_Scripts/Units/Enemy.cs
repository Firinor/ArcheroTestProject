using Damage;
using EnemyBehaviourNamespace;
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            CollisionAttack();
        }
    }

    private void Cooldown()
    {
        weapon.CooldownTick(Time.fixedDeltaTime);
    }
    public void SetBehavior(EnemyBehavior newBehavior)
    {
        behavior.SetState(newBehavior);
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
        Vector3 startPosition;
        if (bulletSpawnPoint == null)
            startPosition = transform.position;
        else
            startPosition = bulletSpawnPoint.position;

        Ray ray = new Ray(startPosition, DirectionTo(Target));

        LayerMask mask = new LayerMask();
        mask.value = LayerMask.GetMask(basisStats.EnemyLayer) + LayerMask.GetMask("Ground");

        if (!Physics.Raycast(ray, out RaycastHit hit, maxDistance: int.MaxValue, layerMask: mask))
            return false;

        if (hit.collider.tag == basisStats.EnemyTag)
            return true;

        return false;

        Vector3 DirectionTo(Vector3 target)
        {
            return target - startPosition;
        }
    }
    public void Attack()
    {
        if (IsPlayerInSight())
        {
            weapon.Attack(GenerateRangetData());
        }
    }
    private void CollisionAttack()
    {
        weapon.Attack(GenerateMeleeData());
    }
    private object GenerateRangetData()
    {
        return new {
            basisStats.Damage,
            basisStats.AttackRate,
            SpawnPosition = bulletSpawnPoint.position,
            Target,
            Filter = new string[] { basisStats.EnemyTag, "Ground" }};
    }
    private object GenerateMeleeData()
    {
        return new {
            basisStats.Damage,
            basisStats.AttackRate,
            Target = player};
    }

    public override void TakeHit(object attackData)
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
