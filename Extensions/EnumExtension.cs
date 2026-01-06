using System.Collections.Concurrent;
using System.Reflection;

namespace Enum2String;

/// <summary>
/// Provides extension methods for converting enum values to their custom string representations
/// using <see cref="StringValueAttribute"/> and <see cref="DefaultStringValueAttribute"/>.
/// </summary>
/// <remarks>
/// <para>
/// This class implements a caching mechanism to optimize reflection operations when
/// converting enum values to their string representations. Caches are thread-safe
/// using <see cref="ConcurrentDictionary{TKey, TValue}"/>.
/// </para>
/// <para>
/// The precedence order for string values is:
/// 1. <see cref="StringValueAttribute"/> on the enum member (even if empty)
/// 2. <see cref="DefaultStringValueAttribute"/> on the enum type
/// 3. The enum member's name as a string
/// </para>
/// </remarks>
public static class EnumExtension
{
    private static ConcurrentDictionary<(Type, string), string> value_cache = [];
    private static ConcurrentDictionary<Type, (string value, bool has)> default_value_cache = [];

#if NET10_0_OR_GREATER
    extension(Enum value)
    {
        /// <summary>
        /// Extension method that returns the custom string representation of an enum value.
        /// </summary>
        /// <param name="value">The enum value to convert.</param>
        /// <returns>
        /// The custom string representation if defined by attributes, otherwise:
        /// - The default string value if <see cref="DefaultStringValueAttribute"/> is applied
        /// - The enum member's name as a string
        /// </returns>
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

        /// <summary>
        /// Determines whether the enum value has a custom string value defined
        /// via <see cref="StringValueAttribute"/>.
        /// </summary>
        /// <param name="value">The enum value to check.</param>
        /// <returns>
        /// <c>true</c> if the enum member has a <see cref="StringValueAttribute"/>;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method only checks for <see cref="StringValueAttribute"/> on the specific
        /// enum member, not for <see cref="DefaultStringValueAttribute"/> on the enum type.
        /// </remarks>
        public bool HasCustomString()
        {
            Type type = value.GetType();
            StringValueAttribute? attr = type.GetField(value.ToString())?
                                            .GetCustomAttribute<StringValueAttribute>();
            return attr != null;
        }

        /// <summary>
        /// Attempts to get the custom string representation of an enum value.
        /// </summary>
        /// <param name="value">The enum value to convert.</param>
        /// <param name="val">When this method returns, contains the string representation
        /// of the enum value if successful; otherwise, the default value.</param>
        /// <returns>
        /// <c>true</c> if the enum member has a <see cref="StringValueAttribute"/>;
        /// <c>false</c> if it relies on default values or the member name.
        /// </returns>
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
#elif NET8_0_OR_GREATER

    /// <summary>
    /// Extension method that returns the custom string representation of an enum value.
    /// </summary>
    /// <param name="value">The enum value to convert.</param>
    /// <returns>
    /// The custom string representation if defined by attributes, otherwise:
    /// - The default string value if <see cref="DefaultStringValueAttribute"/> is applied
    /// - The enum member's name as a string
    /// </returns>
    public static string GetString(this Enum value)
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

    /// <summary>
    /// Determines whether the enum value has a custom string value defined
    /// via <see cref="StringValueAttribute"/>.
    /// </summary>
    /// /// <param name="value">The enum value to check.</param>
    /// <returns>
    /// <c>true</c> if the enum member has a <see cref="StringValueAttribute"/>;
    /// otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method only checks for <see cref="StringValueAttribute"/> on the specific
    /// enum member, not for <see cref="DefaultStringValueAttribute"/> on the enum type.
    /// </remarks>
    public static bool HasCustomString(this Enum value)
    {
        Type type = value.GetType();
        StringValueAttribute? attr = type.GetField(value.ToString())?
                                        .GetCustomAttribute<StringValueAttribute>();
        return attr != null;
    }

    /// <summary>
    /// Attempts to get the custom string representation of an enum value.
    /// </summary>
    /// <param name="value">The enum value to convert.</param>
    /// <param name="val">When this method returns, contains the string representation
    /// of the enum value if successful; otherwise, the default value.</param>
    /// <returns>
    /// <c>true</c> if the enum member has a <see cref="StringValueAttribute"/>;
    /// <c>false</c> if it relies on default values or the member name.
    /// </returns>
    public static bool TryGetString(this Enum value, out string val)
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