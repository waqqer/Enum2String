namespace Enum2String.Tests;

public class CheckingValueTests
{
    [Fact]
    public void HasValue_Test()
    {
        TestEnum val = TestEnum.WithValue;
        bool result = val.HasCustomString();

        Assert.True(result);
    }

    [Fact]
    public void HasValue_Null_Test()
    {
        TestEnum val = TestEnum.WithoutValue;
        bool result = val.HasCustomString();

        Assert.False(result);
    }

    [Fact]
    public void HasValue_WithDefault_Test()
    {
        TestEnumWithDefault val = TestEnumWithDefault.WithValue;
        bool result = val.HasCustomString();

        Assert.True(result);
    }

    [Fact]
    public void HasValue_Null_WithDefault()
    {
        TestEnumWithDefault val = TestEnumWithDefault.WithoutValue;
        bool result = val.HasCustomString();

        Assert.False(result);
    }
}