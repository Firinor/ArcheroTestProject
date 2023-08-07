using UnityEngine;
using System;
using System.Collections.Generic;

namespace Damage
{
    public struct AttackData
    {
        public Unit Attacker { get; set; }

        // string - ID
        // Type - return T
        // object - data
        public Dictionary<KeyValuePair<string, Type>, object> Data;
    }
}