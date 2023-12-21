using Damage;
using UnityEngine;
using Zenject;

public class MainMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PackerService>().AsSingle().NonLazy();
    }
}