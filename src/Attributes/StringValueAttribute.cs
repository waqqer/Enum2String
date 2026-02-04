namespace Enum2String;

/// <summary>
/// Assigns a custom string value to a specific enum member.
/// Applied to individual enum fields to override any default value
/// specified by <see cref="DefaultStringValueAttribute"/> on the enum type.
/// </summary>
/// <remarks>
/// <para>
/// This attribute allows fine-grained control over the string representation
/// of each enum member. When present on an enum field, it takes precedence
/// over any default value defined for the entire enumeration.
/// </para>
/// <para>
/// Use this attribute when you need specific, non-default string values
/// for particular enum members, or when enum members don't follow a
/// consistent naming pattern.
/// </para>
/// </remarks>
[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class StringValueAttribute : Attribute
{
    /// <summary>
    /// Gets the custom string value assigned to the enum member.
    /// </summary>
    /// <value>
    /// The string representation for this specific enum member.
    /// If empty, indicates that no value should be used (even default
    /// values will be ignored for this member).
    /// </value>
    public string Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StringValueAttribute"/> class
    /// with the specified custom string value.
    /// </summary>
    /// <param name="Value">
    /// The custom string value for this enum member.
    /// If null or empty, an empty string will be stored.
    /// </param>
    /// <remarks>
    /// When an empty string is provided, it indicates that this enum member
    /// should not have any string representation in contexts where
    /// custom string values are expected.
    /// </remarks>
    public StringValueAttribute(string Value)
    {
        if(!string.IsNullOrEmpty(Value))
        {
            this.Value = Value;
        }
        else this.Value = "";
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StringValueAttribute"/> class
    /// with an empty string as the custom value.
    /// </summary>
    /// <remarks>
    /// This constructor explicitly indicates that this enum member
    /// should not participate in custom string conversion, even if
    /// a default value is defined for the enumeration.
    /// </remarks>
    public StringValueAttribute()
    {
        Value = "";
    }
}