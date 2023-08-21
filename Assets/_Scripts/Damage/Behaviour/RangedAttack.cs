using UnityEngine;
using Zenject;

namespace Damage
{
    [CreateAssetMenu(fileName = "RangedAttack", menuName = "GameScriptable/Weapon/RangedAttack")]
    public class RangedAttack : MeleeAttack
    {
        [Inject]
        private BulletFactory bulletFactory;

        public override void Attack(object data)
        {
            bulletFactory.Create(data);
        }
    }
}