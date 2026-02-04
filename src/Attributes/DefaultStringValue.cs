namespace Enum2String;

/// <summary>
/// This attribute sets default enum string value
/// </summary>
[AttributeUsage(AttributeTargets.Enum, AllowMultiple = false)]
public sealed class DefaultStringValueAttribute : Attribute
{
    /// <summary>
    /// Contains string value representation
    /// </summary>
    public string Value { get; private set; }

    /// <summary>
    /// Attribute constructor to set default enum string value represent
    /// </summary>
    /// <param name="Value">New string representation</param>
    public DefaultStringValueAttribute(string Value)
        => this.Value = Value;
}