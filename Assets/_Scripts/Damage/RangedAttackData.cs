using UnityEngine;

namespace Damage
{
    public class RangedAttackData : AttackData
    {
        public Vector3 spawnPosition { get; set; }
        public Vector3 target { get; set; }
        public string[] tagMask { get; set; }
    }
}