namespace Enum2String;

/// <summary>
/// Specifies a default string value for all members of an enumeration type.
/// Applied to the enumeration type itself, this attribute defines a base value
/// that will be used when no explicit string value is defined for a specific
/// enum member via <see cref="StringValueAttribute"/>.
/// </summary>
/// <remarks>
/// <para>
/// This attribute is particularly useful when most or all enum members share
/// a common string pattern or prefix. It reduces redundancy and ensures
/// consistency across the enumeration.
/// </para>
/// <para>
/// The default value can be overridden on individual enum members by applying
/// the <see cref="StringValueAttribute"/> to those specific members.
/// </para>
/// </remarks>
[AttributeUsage(AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
public sealed class DefaultStringValueAttribute : Attribute
{
    /// <summary>
    /// Gets the default string value for the enumeration.
    /// </summary>
    /// <value>
    /// The default string value that will be used as a base for enum members
    /// when no explicit string value is defined.
    /// </value>
    public string Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultStringValueAttribute"/> class
    /// with the specified default value.
    /// </summary>
    /// <param name="value">The default string value for the enumeration.</param>
    /// <remarks>
    /// If the provided value is null or empty, an empty string will be used.
    /// </remarks>
    public DefaultStringValueAttribute(string Value)
    {
        if(!string.IsNullOrEmpty(Value))
        {
            this.Value = Value;
        }
        else this.Value = "";
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultStringValueAttribute"/> class
    /// with an empty string as the default value.
    /// </summary>
    /// <remarks>
    /// This constructor is provided for cases where you want to explicitly
    /// set no default value, or when the default value will be constructed
    /// dynamically by your library's logic.
    /// </remarks>
    public DefaultStringValueAttribute()
    {
        Value = "";
    }
}