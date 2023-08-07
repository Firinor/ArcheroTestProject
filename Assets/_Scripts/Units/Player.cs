using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;
using PlayerBehaviourNamespace;
using Damage;

public class Player : Unit
{
    [Inject]
    private VisibleFloatingJoystick joystick;
    [Inject]
    private Level level;

    [SerializeField]
    private PlayerBehavior startBehavior;
    [SerializeField]
    private Aim aim;
    [SerializeField]
    private UnitStats basisStats;
    [SerializeField]
    private Weapon attackScript;
    [SerializeField]
    private AttackData attackData;
    private PlayerBehaviourStateMachine behavior;
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

    private CompositeDisposable disposables = new CompositeDisposable();

    public override void Awake()
    {
        base.Awake();
        behavior = new PlayerBehaviourStateMachine(startBehavior, this);
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
        MovePoint = joystick.Direction;
        behavior.Tick();
    }

    public void SetBehavior(PlayerBehavior newBehavior)
    {
        behavior.SetState(newBehavior);
    }

    public bool IsAnyEnemy()
    {
        return level.Enemies.Count > 0;
    }
    private void Cooldown()
    {
        currentStats.Cooldown -= Time.fixedDeltaTime;
    }
    public void Attack()
    {
        //attackScript.Attack(GenerateAttackData());
    }

    //private AttackData GenerateAttackData()
    //{
    //    return new AttackData()
    //    {
    //        owner = this,
    //        damage = basisStats.Damage,
    //        //target = Target,
    //        //tagMask = new string[] { "Enemy", "Ground" }
    //    };
    //}

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
        Enemy[] sortedEnemies = level.Enemies.OrderBy(enemy => Vector3.Distance(transform.position, enemy.transform.position)).ToArray();
        //var sortedEnemies = from enemy in level.Enemies
        //                        orderby Vector3.Distance(transform.position, enemy.transform.position)
        //                        select enemy;
        return sortedEnemies;
    }
    public bool TargetIsInSight(Vector3 target)
    {
        Ray ray = new Ray(bulletSpawnPoint.position, DirectionTo(target));

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
    public void LookAtEnemy()
    {   
        transform.LookAt(Target);
    }

    public bool IsJoystickDirection()
    {
        return joystick.Direction.x != 0 || joystick.Direction.y != 0;
    }

    public override void Damage(float damage)
    {
        Debug.Log($"Damage {(int)damage}!");
        currentStats.Helth -= (int)damage;
        if (currentStats.Helth <= 0)
            Death();

    }

    private class CurrentStats
    {
        public int Helth;
        public float Cooldown;
        public Enemy Target;
    }
}