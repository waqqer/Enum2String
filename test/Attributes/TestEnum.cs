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

[DefaultStringValue("Color: {Value}", ValueReplaceOption.Replace)]
public enum TestEnumWithReplaceOption
{
    [StringValue("Blue color")]
    Blue,
    White
}