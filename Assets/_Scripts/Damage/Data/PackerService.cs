using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Zenject;

namespace Damage
{
    public class PackerService : MonoBehaviour
    {
        [Inject]
        private DefaultAttackData @default;

        public T GetParameter<T>(string name, AttackData attackData)
        {
            var key = new KeyValuePair<string, Type> (name, typeof(T));

            if (attackData.Data.ContainsKey(key))
                return (T)attackData.Data[key];

            FieldInfo field = @default.GetType().GetField(name);
            if(field != null)
                return (T)field.GetValue(@default);

            throw new Exception($"No field named \"{ name }\" found in attackData or default values");
        }
    }
}
