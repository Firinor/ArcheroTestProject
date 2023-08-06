using UnityEngine;

namespace Damage
{
    public struct BulletData
    {
        //public int damage;
        //public Vector3 spawnPosition;
        //public Vector3 target;

        public float speed;
        public float lifeTime;
        //public string[] tagMask;

        public BulletData(float speed, float lifeTime)
        {
            //owner = shooterData.owner;
            //damage = shooterData.damage;
            //spawnPosition = shooterData.spawnPosition;
            //target = shooterData.target;
            //tagMask = shooterData.tagMask;

            this.speed = speed;
            this.lifeTime = lifeTime;
        }
    }
}