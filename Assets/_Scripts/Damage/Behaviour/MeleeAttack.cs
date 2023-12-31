using UnityEngine;

namespace Damage
{
    [CreateAssetMenu(fileName = "MeleeAttack", menuName = "GameScriptable/Weapon/MeleeAttack")]
    public class MeleeAttack : WeaponBehaviour
    {
        public override void Attack(object data)
        {
            Unit attacked = packer.GetParameter<Unit>(Stat.Target, data, isUnsafe: true);
            attacked.TakeHit(data);
        }
    }
}
