using TMPro;
using UnityEngine;
using Zenject;

public class MainMonoInstaller : MonoInstaller
{
    [SerializeField]
    private BulletFactory bulletFactory;

    public override void InstallBindings()
    {
        //Container.Bind<TimeData>().AsSingle();
        //Container.Bind<AlarmData>().AsSingle();

        //Container.Bind<ClockViewUtil>().AsSingle();
        //Container.Bind<AlarmView>().AsSingle();
        //Container.Bind<TimeView>().AsSingle().NonLazy();

        //Container.Bind<TimeAcquisitionAPI>().AsSingle();

        //Container.BindInstance(backgroundTask).AsSingle();
        //Container.BindInstance(timeGetter).AsSingle();

        //Container.Bind<TimeState>().AsSingle();
        //Container.Bind<AlarmState>().AsSingle();

        //Container.BindFactory<Bullet, BulletFactory>().FromInstance(bulletFactory);
    }
}