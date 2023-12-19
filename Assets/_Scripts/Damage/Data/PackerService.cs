using System;
using Zenject;

namespace Damage
{
    public class PackerService
    {
        [Inject]
        private DefaultAttackDataValues @default;

        public T GetParameter<T>(Stat stat, object data)
        {
            return GetParameter<T>(stat, data, false);
        }
        public T GetParameter<T>(Stat stat, object data, bool isUnsafe)
        {
            object value = null;

            var property = data.GetType().GetProperty(stat.ToString());
            if(property != null )
                value = property.GetValue(data);
            else if(isUnsafe)
                throw new Exception($"It is expected that there will be a type of \"{stat}\" in the data!");

            if (value is T)
                return (T)value;
            else if (isUnsafe)
                throw new Exception($"Field named \"{stat}\" does not match the returned type \"{typeof(T)}\"!");

            if (@default.IsThereDefaultValue(stat))
            {
                return @default.GetValue<T>(stat, isUnsafe);
            }

            if (isUnsafe)
                throw new Exception($"No field named \"{stat}\" found in attackData or default values!");

            return default;
        }
    }
}