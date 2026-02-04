using System.Reflection;

namespace Enum2String;

/// <summary>
/// This attribute sets enum field string value
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public sealed class StringValueAttribute : Attribute, IValueRepresent
{
    /// <summary>
    /// Contains string value representation
    /// </summary>
    public string Value { get; private set; }

    /// <summary>
    /// Attribute constructor to set enum field string value represent
    /// </summary>
    /// <param name="Value">New string representation</param>
    public StringValueAttribute(string Value)
        => this.Value = Value;

    internal static StringValueAttribute? Get(Type type, string name)
    {
        StringValueAttribute? attr = type.GetField(name)?.GetCustomAttribute<StringValueAttribute>();
        return attr;
    }
}