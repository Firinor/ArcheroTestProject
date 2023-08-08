using Damage;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "GameScriptable/SettingsInstaller")]
class ScriptableObjectInstaller :ScriptableObjectInstaller<ScriptableObjectInstaller>
{
    [SerializeField]
    private GameConfiguration gameSettings;
    [SerializeField]
    private DefaultAttackDataValues defaultAttackDataValues;

    public override void InstallBindings()
    {
        Container.BindInstance(gameSettings).AsSingle();
        Container.BindInstance(defaultAttackDataValues).AsSingle();
        //Container.BindInstance(backgroundTaskSettings).AsSingle();
        //Container.BindInstance(alarmSettings).AsSingle();
    }
}
