namespace Enum2String;

[AttributeUsage(AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
public sealed class DefaultStringValueAttribute : Attribute
{
    public string Value { get; }

    public DefaultStringValueAttribute(string Value)
    {
        if(!string.IsNullOrEmpty(Value))
        {
            this.Value = Value;
        }
        else this.Value = "";
    }
    public DefaultStringValueAttribute()
    {
        Value = "";
    }
}