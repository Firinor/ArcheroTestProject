using UnityEngine;

namespace Damage
{
    [CreateAssetMenu(fileName = "DefaultAttackData", menuName = "GameScriptable/Attack/DefaultAttackData")]
    public class DefaultAttackData : ScriptableObject
    {
        public int Damage;
        public float BulletLifeTime;
        public float BulletSpeed;
        public Bullet BulletPrefab;
    }
}
