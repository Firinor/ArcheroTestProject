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
        private DefaultAttackDataValues @default;
        private bool IsThereDefaultValue(string name)
        {
            return IsThereDefaultValue(name, out FieldInfo field);
        }
        private bool IsThereDefaultValue(string name, out FieldInfo field)
        {
            field = @default.GetType().GetField(name);
            return field != null;
        }

        public T GetDefaultParameter<T>(string name)
        {
            return GetDefaultParameter<T>(name, false);
        }
        public T GetDefaultParameter<T>(string name, bool isUnsafe)
        {
            if(IsThereDefaultValue(name, out FieldInfo field))
            {
                object result = field.GetValue(@default);
                if (result is T)
                    return (T)result;
                else if (isUnsafe)
                    throw new Exception($"Default value named \"{ name }\" does not match the returned type!");
            }

            return default;
        }
        public T GetParameter<T>(string name, AttackData attackData)
        {
            return GetParameter<T>(name, attackData, false);
        }
        public T GetParameter<T>(string name, AttackData attackData, bool isUnsafe)
        {
            object result;

            var key = new KeyValuePair<string, Type> (name, typeof(T));

            if (attackData.Data.ContainsKey(key))
            {
                result = attackData.Data[key];
                if (result is T)
                    return (T)result;
                else if (isUnsafe)
                    throw new Exception($"Field named \"{ name }\" does not match the returned type!");
            }

            if (IsThereDefaultValue(name))
            {
                return GetDefaultParameter<T>(name, isUnsafe);
            }

            if (isUnsafe)
                throw new Exception($"No field named \"{ name }\" found in attackData or default values!");

            return default;
        }

        public void SetParameter<T>(string ID, T value, ref AttackData attackData)
        {
            SetParameter(ID, value, ref attackData.Data);
        }
        public void SetParameter<T>(string ID, T value, ref AttackContainer dataDictionary)
        {
            var key = new KeyValuePair<string, Type>(ID, typeof(T));

            if (dataDictionary.ContainsKey(key))
            {
                dataDictionary[key] = value;
                return;
            }

            dataDictionary.Add(key, value);
        }
        public AttackData SetParameters<T>(T dataSource)
        {
            var dataDictionary = new AttackContainer();

            FieldInfo[] fields = typeof(T).GetFields();

            foreach(FieldInfo field in fields)
            {
                string ID = field.Name;
                Type type = field.FieldType;
                object value = field.GetValue(dataSource);
                var key = new KeyValuePair<string, Type>(ID, type);

                if (dataDictionary.ContainsKey(key))
                {
                    dataDictionary[key] = value;
                    continue;
                }

                dataDictionary.Add(key, value);
            }

            return new AttackData(dataDictionary);
        }
        public AttackData AddParameters<T>(T dataSource, ref AttackData attackData, bool ifMatchReplace = true)
        {
            AttackContainer dataDictionary = attackData.Data;

            FieldInfo[] fields = typeof(T).GetFields();

            foreach (FieldInfo field in fields)
            {
                string ID = field.Name;
                Type type = field.FieldType;
                object value = field.GetValue(dataSource);
                var key = new KeyValuePair<string, Type>(ID, type);

                if (dataDictionary.ContainsKey(key))
                {
                    if(ifMatchReplace)
                        dataDictionary[key] = value;
                    continue;
                }

                dataDictionary.Add(key, value);
            }

            return new AttackData(dataDictionary);
        }
    }
}
