using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "GameScriptable/SettingsInstaller")]
class ScriptableObjectInstaller :ScriptableObjectInstaller<ScriptableObjectInstaller>
{
    [SerializeField]
    private GameConfiguration gameSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(gameSettings).AsSingle();
        //Container.BindInstance(internetSettings).AsSingle();
        //Container.BindInstance(backgroundTaskSettings).AsSingle();
        //Container.BindInstance(alarmSettings).AsSingle();
    }
}
