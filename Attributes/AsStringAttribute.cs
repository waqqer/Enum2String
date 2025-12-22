namespace Enum2String;

/// <summary>
/// Attribute that provides custom string representation for enum values.
/// Apply to enum fields to specify alternative string names.
/// </summary>
[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class AsStringAttribute : Attribute
{
    /// <summary>
    /// Gets the string representation of the enum value.
    /// </summary>
    public string name { get; }

    /// <summary>
    /// Initializes attribute with custom string name.
    /// </summary>
    /// <param name="name">Field string</param
    public AsStringAttribute(string name)
           => this.name = name;
    
    /// <summary>
    /// Initializes attribute with default name "none".
    /// </summary>
    public AsStringAttribute() : this("none") {}
}