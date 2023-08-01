using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BulletFactory : MonoBehaviour
{
    [SerializeField]
    private List<Bullet> bullets;
    [SerializeField]
    private Bullet prefab;
    [Inject]
    private GameConfiguration configuration;

    public void Create(ShooterData data)
    {
        BulletData bulletData = new BulletData(data, configuration.BulletSpeed, configuration.BulletLifeTime);

        Bullet result = bullets.Find(b => !b.gameObject.activeSelf);

        if (result == null)
        {
            result = Instantiate(prefab, transform);
            bullets.Add(result);
        }

        result.Init(bulletData);
    }
}