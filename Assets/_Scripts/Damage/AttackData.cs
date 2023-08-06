using UnityEngine;
using System;

namespace Damage
{
    [Serializable]
    public class AttackData : ScriptableObject
    {
        public Unit owner { get; set; }
        public int damage { get; set; }
    }
}