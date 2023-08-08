using UnityEngine;
using Zenject;

namespace Damage
{
    public abstract class WeaponBehaviour : ScriptableObject
    {
        [Inject]
        protected PackerService packer;

        public abstract void Attack(AttackData data);
    }
}
