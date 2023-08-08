using System.Collections.Generic;
using UnityEngine;

namespace Damage
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField]
        private List<Bullet> bullets;
        [SerializeField]
        private Bullet prefab;

        public void Create(AttackData attackData)
        {
            Bullet result = bullets.Find(b => !b.gameObject.activeSelf);

            if (result == null)
            {
                result = Instantiate(prefab, transform);
                bullets.Add(result);
            }

            result.Init(attackData);
        }
    }
}