using System.Reflection;

namespace Enum2String;

/// <summary>
/// Provides extension methods for converting enum values to custom string representations.
/// </summary>
public static class EnumExtension
{
    /// <summary>
    /// Converts enum value to custom string representation if defined by <see cref="AsStringAttribute"/>,
    /// otherwise returns default enum name.
    /// </summary>
    /// <param name="value">The enum value to convert.</param>
    /// <returns>Custom string if attribute exists, otherwise enum name.</returns>
    /// <example>
    /// <code>
    /// [AsString("Active User")]
    /// Active,
    /// 
    /// var result = Status.Active.AsString(); // Returns "Active User"
    /// </code>
    /// </example>
    public static string AsString(this Enum value)
    {
        FieldInfo? fi = value.GetType().GetField(value.ToString());
        return fi?.GetCustomAttribute<AsStringAttribute>()?.name ?? value.ToString();
    }

    /// <summary>
    /// Checks if enum value has custom string representation defined by <see cref="AsStringAttribute"/>.
    /// </summary>
    /// <param name="value">The enum value to check.</param>
    /// <returns>True if custom string representation exists, otherwise false.</returns>
    public static bool HasString(this Enum value)
    {
        FieldInfo? fi = value.GetType().GetField(value.ToString());
        return fi?.GetCustomAttribute<AsStringAttribute>() != null;
    }

    /// <summary>
    /// Attempts to get custom string representation for enum value.
    /// </summary>
    /// <param name="value">The enum value to convert.</param>
    /// <param name="name">Output parameter containing the string representation.</param>
    /// <returns>True if custom string exists, false if default enum name is used.</returns>
    /// <remarks>
    /// The output parameter always contains a valid string - either custom representation 
    /// or default enum name.
    /// </remarks>
    public static bool TryGetString(this Enum value, out string name)
    {
        FieldInfo? fi = value.GetType().GetField(value.ToString());
        AsStringAttribute? attr = fi?.GetCustomAttribute<AsStringAttribute>();
        name = attr is null ? value.ToString() : attr.name;
        return attr is not null;
    }
}