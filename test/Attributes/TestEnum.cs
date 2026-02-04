namespace Enum2String.Tests;

public enum TestEnum
{
    [StringValue("Value")]
    WithValue,
    WithoutValue,
    SomeValue
}

[DefaultStringValue("Default_Value")]
public enum TestEnumWithDefault
{
    [StringValue("Value")]
    WithValue,
    WithoutValue,
    SomeValue
}