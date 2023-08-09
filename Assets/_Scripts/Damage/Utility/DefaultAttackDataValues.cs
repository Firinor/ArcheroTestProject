using System;
using System.Collections.Generic;
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

        public bool IsThereDefaultValue(Stat stat)
        {
            List<Stat> list = new List<Stat>()
            {
                Stat.Damage,
                Stat.LifeTime,
                Stat.Speed,
                Stat.BulletPrefab
            };

            return list.Contains(stat);
        }

        public T GetValue<T>(Stat stat, bool isUnsafe)
        {
            switch (stat)
            {
                case Stat.Damage:
                    if(Damage is T resultDamage)
                        return resultDamage;
                    goto default;
                case Stat.LifeTime:
                    if (BulletLifeTime is T resultTime)
                        return resultTime;
                    goto default;
                case Stat.Speed:
                    if (BulletSpeed is T resultSpeed)
                        return resultSpeed;
                    goto default;
                case Stat.BulletPrefab:
                    if (BulletPrefab is T resultBulletPrefab)
                        return resultBulletPrefab;
                    goto default;
                default:
                    if (isUnsafe)
                        throw new Exception($"Default value named \"{ stat }\" does not match the returned type!");
                    else
                        return default;
            }
        }
    }
}
