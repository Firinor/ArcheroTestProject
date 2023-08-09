using UnityEngine;
using Zenject;

namespace Damage
{
    [CreateAssetMenu(fileName = "RangedAttack", menuName = "GameScriptable/Weapon/RangedAttack")]
    public class RangedAttack : MeleeAttack
    {
        [Inject]
        private BulletFactory bulletFactory;

        public void Init(PackerService packer, BulletFactory bulletFactory)
        {
            Init(packer);
            this.bulletFactory = bulletFactory;
        }

        public override void Attack(AttackData data)
        {
            bulletFactory.Create(data);
        }
    }
}