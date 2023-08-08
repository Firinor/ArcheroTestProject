using UnityEngine;

namespace Damage
{
    public struct BulletData
    {
        public Unit owner;
        public int damage;
        public Vector3 spawnPosition;
        public Vector3 target;

        public float speed;
        public float lifeTime;
        public string[] tagMask;
    }
}