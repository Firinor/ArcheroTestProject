using UnityEngine;
using Zenject;

namespace Damage
{
    public abstract class WeaponBehaviour : ScriptableObject
    {
        protected PackerService packer => ServiceLocator.PackerService;

        public abstract void Attack(AttackData data);
    }
}
