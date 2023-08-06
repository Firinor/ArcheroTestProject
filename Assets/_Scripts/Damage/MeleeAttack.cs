using System;
using UnityEngine;

namespace Damage
{
    [CreateAssetMenu(fileName = "MeleeAttack", menuName = "GameScriptable/Weapon/MeleeAttack")]
    public class MeleeAttack : ScriptableObject
    {
        public AttackData attackData;

        public virtual void Attack(AttackData data)
        {
            
        }
    }
}
