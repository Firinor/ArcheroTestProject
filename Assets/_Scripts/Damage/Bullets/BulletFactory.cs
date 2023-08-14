using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Damage
{
    public class BulletFactory : MonoBehaviour, IFactory<AttackData, Bullet>
    {
        [SerializeField]
        private List<Bullet> bullets;
        [SerializeField]
        private Bullet prefab;
        [Inject]
        private DiContainer container;


        public Bullet Create(AttackData param)
        {
            Bullet result = bullets.Find(b => !b.gameObject.activeSelf);

            if (result == null)
            {
                result = container.InstantiatePrefabForComponent<Bullet>(prefab, transform);
                //result = Instantiate(prefab, transform);
                bullets.Add(result);
            }

            result.Init(param); 

            return result;
        }
    }
}