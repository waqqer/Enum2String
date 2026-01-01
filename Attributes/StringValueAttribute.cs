namespace Enum2String;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class StringValueAttribute : Attribute
{
    public string Value { get; }

    public StringValueAttribute(string Value)
    {
        if(!string.IsNullOrEmpty(Value))
        {
            this.Value = Value;
        }
        else this.Value = "";
    }
    public StringValueAttribute()
    {
        Value = "";
    }
}