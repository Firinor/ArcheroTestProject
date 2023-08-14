using UnityEngine;
using Zenject;

namespace Damage
{
    [CreateAssetMenu(fileName = "RangedAttack", menuName = "GameScriptable/Weapon/RangedAttack")]
    public class RangedAttack : MeleeAttack
    {
        [Inject]
        private BulletFactory bulletFactory;

        public override void Attack(AttackData data)
        {
            bulletFactory.Create(data);
        }
    }
}