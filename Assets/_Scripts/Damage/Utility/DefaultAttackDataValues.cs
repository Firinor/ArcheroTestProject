using UnityEngine;

namespace Damage
{
    [CreateAssetMenu(fileName = "DefaultAttackData", menuName = "GameScriptable/Attack/DefaultAttackData")]
    public class DefaultAttackDataValues : ScriptableObject
    {
        public int Damage;
        public float BulletLifeTime;
        public float BulletSpeed;
        public Bullet BulletPrefab;
    }
}
