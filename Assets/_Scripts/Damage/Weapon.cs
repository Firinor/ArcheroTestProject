using System;
using UnityEngine;
using Zenject;

namespace Damage
{
    [Serializable]
    public class Weapon
    {
        [Inject]
        private PackerService packer;
        [SerializeField]
        private WeaponBehaviour behaviour;
        private float Cooldown;
        public bool isReady => Cooldown <= 0;

        public void Attack(AttackData data)
        {
            if (Cooldown <= 0)
            {
                Cooldown += packer.GetParameter<float>("AttackRate", data);
                behaviour.Attack(data);
            }
        }

        public void CooldownTick(float time)
        {
            Cooldown = Math.Max(Cooldown - time, 0f);
        }
    }
}
