namespace Enum2String;

/// <summary>
/// Interface to group all attribute for enum value represent
/// <br/><br/>
/// Basic attributes:
/// <br/>
/// <see cref="DefaultStringValueAttribute"/> and
/// <see cref="StringValueAttribute"/>
/// </summary>
public interface IValueRepresent
{
    /// <summary>
    /// Enum string value
    /// </summary>
    string Value { get; }
}