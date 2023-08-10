using Damage;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "GameScriptable/SettingsInstaller")]
class ScriptableObjectInstaller :ScriptableObjectInstaller<ScriptableObjectInstaller>
{
    [SerializeField]
    private DefaultAttackDataValues defaultAttackDataValues;

    public override void InstallBindings()
    {
        Container.BindInstance(defaultAttackDataValues).AsSingle();
    }
}
