using System.Collections.Concurrent;
using System.Reflection;

namespace Enum2String;

public static class EnumExtension
{
    private static ConcurrentDictionary<(Type, string), string> value_cache = [];
    private static ConcurrentDictionary<Type, (string value, bool has)> default_value_cache = [];

#if NET10_0_OR_GREATER
    extension(Enum value)
    {
        public string GetString()
        {
            Type type = value.GetType();
            string d_name = value.ToString();
            if (value_cache.ContainsKey((type, d_name)))
                return value_cache[(type, d_name)];

            StringValueAttribute? attr = type.GetField(d_name)?.GetCustomAttribute<StringValueAttribute>();
            string result;
            if (attr is null)
            {
                if (default_value_cache.ContainsKey(type))
                    result = default_value_cache[type].value;
                else
                {
                    DefaultStringValueAttribute? def_attr = type.GetCustomAttribute<DefaultStringValueAttribute>();
                    if (def_attr is not null)
                    {
                        result = def_attr.Value;
                        default_value_cache.TryAdd(type, (def_attr.Value, true));
                    }
                    else
                    {
                        result = d_name;
                        default_value_cache.TryAdd(type, ("", false));
                    }
                }
            }
            else result = attr.Value;
            value_cache.TryAdd((type, d_name), result);
            return result;
        }

        public bool HasCustomString()
        {
            Type type = value.GetType();
            StringValueAttribute? attr = type.GetField(value.ToString())?
                                            .GetCustomAttribute<StringValueAttribute>();
            return attr != null;
        }

        public bool TryGetString(out string val)
        {
            Type type = value.GetType();
            string d_name = value.ToString();
            StringValueAttribute? attr = type.GetField(d_name)?.GetCustomAttribute<StringValueAttribute>();
            if (value_cache.ContainsKey((type, d_name)))
            {
                val = value_cache[(type, d_name)];
                return attr != null;
            }
            string result;
            if (attr is null)
            {
                if (default_value_cache.ContainsKey(type))
                    result = default_value_cache[type].value;
                else
                {
                    DefaultStringValueAttribute? def_attr = type.GetCustomAttribute<DefaultStringValueAttribute>();
                    if (def_attr is not null)
                    {
                        result = def_attr.Value;
                        default_value_cache.TryAdd(type, (def_attr.Value, true));
                    }
                    else
                    {
                        result = d_name;
                        default_value_cache.TryAdd(type, ("", false));
                    }
                }
            }
            else result = attr.Value;
            value_cache.TryAdd((type, d_name), result);
            val = result;
            return attr != null;
        }
    }
#endif

#if NET8_0_OR_GREATER
    public static string GetString(this string value)
    {
        Type type = value.GetType();
        string d_name = value.ToString();
        if (value_cache.ContainsKey((type, d_name)))
            return value_cache[(type, d_name)];

        StringValueAttribute? attr = type.GetField(d_name)?.GetCustomAttribute<StringValueAttribute>();
        string result;
        if (attr is null)
        {
            if (default_value_cache.ContainsKey(type))
                result = default_value_cache[type].value;
            else
            {
                DefaultStringValueAttribute? def_attr = type.GetCustomAttribute<DefaultStringValueAttribute>();
                if (def_attr is not null)
                {
                    result = def_attr.Value;
                    default_value_cache.TryAdd(type, (def_attr.Value, true));
                }
                else
                {
                    result = d_name;
                    default_value_cache.TryAdd(type, ("", false));
                }
            }
        }
        else result = attr.Value;
        value_cache.TryAdd((type, d_name), result);
        return result;
    }

    public static bool HasCustomString(this string value)
    {
        Type type = value.GetType();
        StringValueAttribute? attr = type.GetField(value.ToString())?
                                        .GetCustomAttribute<StringValueAttribute>();
        return attr != null;
    }

    public static bool TryGetString(this string value, out string val)
    {
        Type type = value.GetType();
        string d_name = value.ToString();
        StringValueAttribute? attr = type.GetField(d_name)?.GetCustomAttribute<StringValueAttribute>();
        if (value_cache.ContainsKey((type, d_name)))
        {
            val = value_cache[(type, d_name)];
            return attr != null;
        }
        string result;
        if (attr is null)
        {
            if (default_value_cache.ContainsKey(type))
                result = default_value_cache[type].value;
            else
            {
                DefaultStringValueAttribute? def_attr = type.GetCustomAttribute<DefaultStringValueAttribute>();
                if (def_attr is not null)
                {
                    result = def_attr.Value;
                    default_value_cache.TryAdd(type, (def_attr.Value, true));
                }
                else
                {
                    result = d_name;
                    default_value_cache.TryAdd(type, ("", false));
                }
            }
        }
        else result = attr.Value;
        value_cache.TryAdd((type, d_name), result);
        val = result;
        return attr != null;
    }
#endif
}