using System.Reflection;

namespace Enum2String;

/// <summary>
/// This attribute sets default enum string value
/// </summary>
[AttributeUsage(AttributeTargets.Enum, AllowMultiple = false)]
public sealed class DefaultStringValueAttribute : Attribute, IValueRepresent
{
    /// <summary>
    /// Contains string value representation
    /// </summary>
    public string Value { get; private set; }
    public ValueReplaceOption Option { get; private set; } = ValueReplaceOption.None;

    /// <summary>
    /// Attribute constructor to set default enum string value represent
    /// </summary>
    /// <param name="Value">New string representation</param>
    public DefaultStringValueAttribute(string Value)
        => this.Value = Value;

    public DefaultStringValueAttribute(string Value, ValueReplaceOption Option) : this(Value)
        => this.Option = Option;

    internal static DefaultStringValueAttribute? Get(Type type)
    {
        DefaultStringValueAttribute? attr = type.GetCustomAttribute<DefaultStringValueAttribute>();
        return attr;
    }
}