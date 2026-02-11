namespace Enum2String;

internal static class ValueValidator
{
    public static string GetDefaultOrCustomValue(Enum value)
    {
        Type type = value.GetType();
        string name = value.ToString();

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
            return ValueReplacer.GetValueByReplaceOption(default_attr, name);
        }

        return name;
    }


    public static bool CustomValueExists(Enum value)
    {
        Type type = value.GetType();
        string name = value.ToString();

        if(ValueExistsCache.Has(type, name))
            return ValueExistsCache.Get(type, name);
        
        StringValueAttribute? attr = StringValueAttribute.Get(type, name);

        bool exists = attr is not null;
        ValueExistsCache.Add(type, name, exists);
        return exists;
    }

    public static bool TryGetCustomValue(Enum value, out string field_name)
    {
        field_name = GetDefaultOrCustomValue(value);
        return CustomValueExists(value);
    }
}