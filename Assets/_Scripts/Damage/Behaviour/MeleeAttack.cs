using System;
using UnityEngine;

namespace Damage
{
    [CreateAssetMenu(fileName = "MeleeAttack", menuName = "GameScriptable/Weapon/MeleeAttack")]
    public class MeleeAttack : WeaponBehaviour
    {
        public override void Init(PackerService packer)
        {
            this.packer = packer;
        }

        public override void Attack(AttackData data)
        {
            Unit attacked = packer.GetParameter<Unit>(Stat.Target, data);
            attacked.TakeHit(data);
        }

    }
}
