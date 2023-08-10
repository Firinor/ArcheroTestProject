using Damage;
using System;
using UnityEngine;
using Zenject;

public class MainMonoInstaller : MonoInstaller
{
    //[SerializeField]
    //private BulletFactory bulletFactory;

    public override void InstallBindings()
    {
        Container.Bind<PackerService>().AsSingle().NonLazy();
        InitServiceLocator();
    }

    private void InitServiceLocator()
    {
        ServiceLocator.BulletFactory = (BulletFactory)Container.Resolve(typeof(BulletFactory));
        ServiceLocator.PackerService = (PackerService)Container.Resolve(typeof(PackerService));
    }
}