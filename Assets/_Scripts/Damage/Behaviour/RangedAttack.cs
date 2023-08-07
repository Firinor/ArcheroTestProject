using UnityEngine;
using Zenject;

namespace Damage
{
    [CreateAssetMenu(fileName = "RangedAttack", menuName = "GameScriptable/Weapon/RangedAttack")]
    public class RangedAttack : MeleeAttack
    {
        [Inject]
        private BulletFactory bulletFactory;

        public Bullet BulletPrefab;

        //public override void Attack(RangedAttackData data)
        //{
        //    if (data.owner.Cooldown <= 0 && data.owner.TargetIsInSight(data.Target))
        //    {
        //        data.owner.Cooldown += data.AttackRate;
        //        bulletFactory.Create(data);
        //    }
        //}
}
}