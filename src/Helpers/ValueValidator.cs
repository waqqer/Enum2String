namespace Enum2String;

internal static class ValueValidator
{
    public static string GetDefaultOrCustomValue(Enum value)
    {
        Type type = value.GetType();
        string name = nameof(value);

        if (FieldValueCache.Has(type, name))
            return FieldValueCache.Get(type, name);

        StringValueAttribute? attr = StringValueAttribute.Get(type, name);

        if (attr is not null)
        {
            FieldValueCache.Add(type, name, attr.Value);
            return attr.Value;
        }

        if (DefaultValueCache.Has(type))
            return DefaultValueCache.Get(type);

        DefaultStringValueAttribute? default_attr = DefaultStringValueAttribute.Get(type);

        if (default_attr is not null)
        {
            DefaultValueCache.Add(type, default_attr.Value);
            FieldValueCache.Add(type, name, default_attr.Value);
            return default_attr.Value;
        }

        return name;
    }

    public static string GetCustomValue(Enum value)
    {
        Type type = value.GetType();
        string name = nameof(value);

        if (FieldValueCache.Has(type, name))
            return FieldValueCache.Get(type, name);

        StringValueAttribute? attr = StringValueAttribute.Get(type, name);

        if (attr is not null)
        {
            FieldValueCache.Add(type, name, attr.Value);
            return attr.Value;
        }

        return name;
    }

    public static bool CustomValueExists(Enum value)
    {
        Type type = value.GetType();
        string name = nameof(value);

        if(ValueExistsCache.Has(type, name))
            return ValueExistsCache.Get(type, name).Actually;

        DefaultStringValueAttribute? default_attr = DefaultStringValueAttribute.Get(type);
        StringValueAttribute? attr = StringValueAttribute.Get(type, name);

        (bool Act, bool Full) cache = (
                                    attr is not null, 
                                    default_attr is not null
                                    );

        ValueExistsCache.Add(type, name, cache);
        return cache.Act;
    }

    public static bool CustomValueExistsWithDefault(Enum value)
    {
        Type type = value.GetType();
        string name = nameof(value);

        if(ValueExistsCache.TryGet(type, name, out var data))
        {
            if(data.Actually || data.Full)
                return true;
            return false;
        }

        DefaultStringValueAttribute? default_attr = DefaultStringValueAttribute.Get(type);
        StringValueAttribute? attr = StringValueAttribute.Get(type, name);

        (bool Act, bool Full) cache = (
                                    attr is not null, 
                                    default_attr is not null
                                    );

        ValueExistsCache.Add(type, name, cache);

        if(cache.Act || cache.Full)
            return true;
        return false;
    }

    public static bool TryGetCustomValue(Enum value, out string field_name)
    {
        field_name = GetCustomValue(value);
        return CustomValueExists(value);
    }

    public static bool TryGetDefaultOrCustomValue(Enum value, out string field_name)
    {
        field_name = GetDefaultOrCustomValue(value);
        return CustomValueExistsWithDefault(value);
    }
}