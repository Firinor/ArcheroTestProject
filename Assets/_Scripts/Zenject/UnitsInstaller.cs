using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "UnitsInstaller", menuName = "GameScriptable/UnitsInstaller")]
public class UnitsInstaller : ScriptableObjectInstaller<UnitsInstaller>
{
    //[SerializeField]
    //private UnitStats playerStats;
    //[SerializeField]
    //private UnitStats meleeEnemyStats;
    //[SerializeField]
    //private UnitStats rangedEnemyStats;


    public override void InstallBindings()
    {
        //Container.BindInstance(playerStats).WithId("Player").AsTransient();
        //Container.BindInstance(meleeEnemyStats).WithId("MeleeEnemy").AsTransient();
        //Container.BindInstance(rangedEnemyStats).WithId("RangedEnemy").AsTransient();
    }
}