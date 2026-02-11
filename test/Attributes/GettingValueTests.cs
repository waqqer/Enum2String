namespace Enum2String.Tests;

public class GettingValueTests
{
    [Fact]
    public void GetStringValue_Test()
    {
        TestEnum val = TestEnum.WithValue;
        string represent = val.GetString();

        Assert.Equal("Value", represent);
    }

    [Fact]
    public void GetStringValueNull_Test()
    {
        TestEnum val = TestEnum.WithoutValue;
        string represent = val.GetString();

        Assert.Equal("WithoutValue", represent);
    }

    [Fact]
    public void GetStringValue_WithDefault_Test()
    {
        TestEnumWithDefault val = TestEnumWithDefault.WithValue;
        string represent = val.GetString();

        Assert.Equal("Value", represent);
    }

    [Fact]
    public void GetStringValueNull_WithDefault_Test()
    {
        TestEnumWithDefault val = TestEnumWithDefault.WithoutValue;
        string represent = val.GetString();

        Assert.Equal("Default_Value", represent);
    }

    [Fact]
    public void GetStringValue_WithReplace_Test()
    {
        TestEnumWithReplaceOption val = TestEnumWithReplaceOption.Blue;
        string represent = val.GetString();

        Assert.Equal("Blue color", represent);
    }

    [Fact]
    public void GetStringValueNull_WithReplace_Test()
    {
        TestEnumWithReplaceOption val = TestEnumWithReplaceOption.White;
        string represent = val.GetString();

        Assert.Equal("Color: White", represent);
    }
}