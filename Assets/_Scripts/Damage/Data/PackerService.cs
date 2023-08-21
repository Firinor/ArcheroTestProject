using System;
using System.Collections.Generic;
using Zenject;

namespace Damage
{
    public class PackerService
    {
        [Inject]
        private DefaultAttackDataValues @default;

        public T GetParameter<T>(Stat stat, object attackData)
        {
            return GetParameter<T>(stat, attackData, false);
        }
        public T GetParameter<T>(Stat stat, object attackData, bool isUnsafe)
        {
            object result;

            var a = attackData.GetType().GetProperty(Stat.Damage.ToString()).GetValue(attackData);

            var key = new KeyValuePair<Stat, Type>(stat, typeof(T));

            //if (attackData.Data.ContainsKey(key))
            //{
            //    result = attackData.Data[key];
            //    if (result is T)
            //        return (T)result;
            //    else if (isUnsafe)
            //        throw new Exception($"Field named \"{ stat }\" does not match the returned type!");
            //}

            if (@default.IsThereDefaultValue(stat))
            {
                return @default.GetValue<T>(stat, isUnsafe);
            }

            if (isUnsafe)
                throw new Exception($"No field named \"{ stat }\" found in attackData or default values!");

            return default;
        }

        //public void SetParameter<T>(Stat stat, T value, object dataDictionary)
        //{
        //    var key = new KeyValuePair<Stat, Type>(stat, typeof(T));

        //    if (dataDictionary.ContainsKey(key))
        //    {
        //        dataDictionary[key] = value;
        //        return;
        //    }

        //    dataDictionary.Add(key, value);
        //}
        //public AttackData SetParameters<T>(T dataSource)
        //{
        //    var dataDictionary = new AttackContainer();

        //    FieldInfo[] fields = typeof(T).GetFields();

        //    foreach (FieldInfo field in fields)
        //    {
        //        Stat stat = field.Name;
        //        Type type = field.FieldType;
        //        object value = field.GetValue(dataSource);
        //        var key = new KeyValuePair<Stat, Type>(stat, type);

        //        if (dataDictionary.ContainsKey(key))
        //        {
        //            dataDictionary[key] = value;
        //            continue;
        //        }

        //        dataDictionary.Add(key, value);
        //    }

        //    return new AttackData(dataDictionary);
        //}
        //public AttackData AddParameters<T>(T dataSource, ref AttackData attackData, bool ifMatchReplace = true)
        //{
        //    AttackContainer dataDictionary = attackData.Data;

        //    FieldInfo[] fields = typeof(T).GetFields();

        //    foreach (FieldInfo field in fields)
        //    {
        //        Stat stat = field.Name;
        //        Type type = field.FieldType;
        //        object value = field.GetValue(dataSource);
        //        var key = new KeyValuePair<Stat, Type>(stat, type);

        //        if (dataDictionary.ContainsKey(key))
        //        {
        //            if (ifMatchReplace)
        //                dataDictionary[key] = value;
        //            continue;
        //        }

        //        dataDictionary.Add(key, value);
        //    }

        //    return new AttackData(dataDictionary);
        //}
    }
}