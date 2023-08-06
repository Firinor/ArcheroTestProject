using System;
using UnityEngine;

namespace Damage
{
    [Serializable]
    public class Weapon
    {
        public MeleeAttack attack;
        public AttackData data;

        public virtual void Attack()
        {
            attack.Attack(data);
        }
    }
}
