namespace Enum2String;

public static class EnumExtension
{
    extension(Enum value)
    {
        public string GetString()
        {
            Type type = value.GetType();
            string name = nameof(value);

            if(FieldValueCache.Has(type, name))
                return FieldValueCache.Get(type, name);

            StringValueAttribute? attr = StringValueAttribute.Get(type, name);

            if(attr is not null)
            {
                FieldValueCache.Add(type, name, attr.Value);
                return attr.Value;
            }

            if(DefaultValueCache.Has(type))
                return DefaultValueCache.Get(type);

            DefaultStringValueAttribute? default_attr = DefaultStringValueAttribute.Get(type);

            if(default_attr is not null)
            {
                DefaultValueCache.Add(type, default_attr.Value);
                FieldValueCache.Add(type, name, default_attr.Value);
                return default_attr.Value;
            }

            return name;
        }

        public bool HasCustomString(bool IncludeDefault = false)
        {
            // WIP

            return true;
        }

        public bool TryGetString(out string val)
        {
            // WIP

            val = nameof(value);
            return true;
        }
    }
}