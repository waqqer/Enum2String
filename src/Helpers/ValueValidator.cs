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

    public static bool CustomValueExists(Enum value)
    {
        // WIP

        return true;
    }

    public static bool CustomValueExistsWithDefault(Enum value)
    {
        // WIP

        return true;
    }

    public static bool TryGetDefaultOrCustomValue(Enum value, out string field_name)
    {
        // WIP

        field_name = "";
        return true;
    }
}