using System;
using System.Collections.Generic;

namespace Damage
{
    // string - ID
    // Type - return T
    // object - data
    public class AttackContainer : Dictionary<KeyValuePair<Stat, Type>, object> { }
}
