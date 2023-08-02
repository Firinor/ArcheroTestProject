using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

public class Player : Unit, IShooter
{
    [Inject]
    private VisibleFloatingJoystick joystick;
    [Inject]
    private BulletFactory bulletFactory;
    [Inject]
    private Level level;

    [SerializeField]
    private UnitBehavior startBehavior;
    [SerializeField]
    private Aim aim;
    [Inject(Id = "Player")]
    private UnitStats basisStats;
    [SerializeField]
    private CurrentStats currentStats;

    [SerializeField]
    private Transform bulletSpawnPoint;

    public Vector3 Target 
    { 
        get
        {
            if (currentStats.Target == null)
                return Vector3.zero;

            return currentStats.Target.transform.position;
        } 
    }

    public bool IsAnyEnemy()
    {
        return level.EnemiesCount > 0;
    }

    private CompositeDisposable disposables = new CompositeDisposable();

    public override void Awake()
    {
        base.Awake();
        behavior = new UnitBehaviorStateMachine(startBehavior, this);
        currentStats = new CurrentStats()
        {
            Helth = basisStats.Health,
            Cooldown = 0
        };
        FindEnemy();

        Observable.EveryFixedUpdate()
            .Where(_ => currentStats.Cooldown > 0)
            .Subscribe(_ => Cooldown())
            .AddTo(disposables);
    }

    private void Cooldown()
    {
        currentStats.Cooldown -= Time.fixedDeltaTime;
    }

    public void Attack()
    {
        if (currentStats.Cooldown <= 0)
        {
            currentStats.Cooldown += basisStats.AttackRate;
            bulletFactory.Create(GenerateShooterData());
        }
    }

    private ShooterData GenerateShooterData()
    {
        return new ShooterData()
        {
            owner = this,
            damage = basisStats.Damage,
            spawnPosition = bulletSpawnPoint.position,
            target = Target
        };
    }

    public void FindEnemy()
    {
        Enemy[] enemies = GetSortedEnemies();
        for(int i = 0; i < enemies.Length; i++)
        {
            if (TargetIsInSight(enemies[i].transform.position))
            {
                currentStats.Target = enemies[i];
                return;
            }
        }

        if (IsAnyEnemy())
            currentStats.Target = enemies[0];
        else
            currentStats.Target = null;
    }
    private Enemy[] GetSortedEnemies()
    {
        //Enemy[] sortedEnemies = level.Enemies.OrderBy(enemy => Vector3.Distance(transform.position, enemy.transform.position)).ToArray();
        var sortedEnemies = from enemy in level.Enemies
                                orderby Vector3.Distance(transform.position, enemy.transform.position)
                                select enemy;
        DebugDist();
        return sortedEnemies.ToArray();
    }

    private void DebugDist()
    {
        for(int i = 0; i < level.Enemies.Length; i++){
            float dist = Vector3.Distance(transform.position, level.Enemies[i].transform.position);
            Debug.Log($"Enemy {level.Enemies[i].name} on dist {dist}");
        }
    }

    private bool TargetIsInSight(Vector3 target)
    {
        Ray ray = new Ray(transform.position, DirectionTo(target));

        if (!Physics.Raycast(ray, out RaycastHit hit, maxDistance: int.MaxValue, layerMask: LayerMask.GetMask(basisStats.EnemyLayer)))
            return false;

        if (hit.collider.tag == basisStats.EnemyTag)
            return true;

        return false;

        Vector3 DirectionTo(Vector3 target)
        {
            return target - transform.position;
        }
    }

    internal void LookAtEnemy()
    {
        transform.LookAt(Target);
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
        public Enemy Target;
    }
}