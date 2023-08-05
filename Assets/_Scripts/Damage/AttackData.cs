using System;
using UnityEngine;

namespace Attack
{

    [RequireComponent(typeof(Unit))]
    public class AttackData : MonoBehaviour
    {
        private Unit owner;
        private AttackStats attackStats;
        private CurrentStats currentStats;

        private void Awake()
        {
            owner = GetComponent<Unit>();
            attackStats = CompileStats(owner);
        }

        private AttackStats CompileStats(Unit owner)
        {
            throw new NotImplementedException();
        }

        private class CurrentStats
        {
            public int Damage;
            public float Cooldown;
            public Enemy Target;
        }
    }
}
