namespace Enum2String.Tests;

public class TryGettingValueTests
{
    [Fact]
    public void TryGetValue_Test()
    {
        TestEnum val = TestEnum.WithValue;
        bool result = val.TryGetString(false, out _);

        Assert.True(result);
    }

    [Fact]
    public void TryGetValue_Null_Test()
    {
        TestEnum val = TestEnum.WithoutValue;
        bool result = val.TryGetString(false, out _);

        Assert.False(result);
    }

    [Fact]
    public void TryGetValue_NoDefault_Test()
    {
        TestEnumWithDefault val = TestEnumWithDefault.WithValue;
        bool result = val.TryGetString(false, out _);

        Assert.True(result);
    }

    [Fact]
    public void TryGetValue_Null_NoDefault_Test()
    {
        TestEnumWithDefault val = TestEnumWithDefault.WithoutValue;
        bool result = val.TryGetString(false, out _);

        Assert.False(result);
    }

    [Fact]
    public void TryGetValue_WithDefault_Test()
    {
        TestEnumWithDefault val = TestEnumWithDefault.WithValue;
        bool result = val.TryGetString(true, out _);

        Assert.True(result);
    }

    [Fact]
    public void TryGetValue_Null_WithDefault_Test()
    {
        TestEnumWithDefault val = TestEnumWithDefault.WithoutValue;
        bool result = val.TryGetString(true, out _);

        Assert.True(result);
    }

    [Fact]
    public void TryGetValue_Content_Test()
    {
        TestEnum val = TestEnum.WithValue;
        val.TryGetString(false, out string content);

        Assert.Equal("Value", content);
    }

    [Fact]
    public void TryGetValue_Null_Content_Test()
    {
        TestEnum val = TestEnum.WithoutValue;
        val.TryGetString(false, out string content);

        Assert.Equal("WithoutValue", content);
    }

    [Fact]
    public void TryGetValue_Content_NoDefault_Test()
    {
        TestEnumWithDefault val = TestEnumWithDefault.WithValue;
        val.TryGetString(false, out string content);

        Assert.Equal("Value", content);
    }

    [Fact]
    public void TryGetValue_Null_Content_NoDefault_Test()
    {
        TestEnumWithDefault val = TestEnumWithDefault.WithoutValue;
        val.TryGetString(false, out string content);

        Assert.Equal("WithoutValue", content);
    }

    [Fact]
    public void TryGetValue_Content_WithDefault_Test()
    {
        TestEnumWithDefault val = TestEnumWithDefault.WithValue;
        val.TryGetString(true, out string content);

        Assert.Equal("Value", content);
    }

    [Fact]
    public void TryGetValue_Null_Content_WithDefault_Test()
    {
        TestEnumWithDefault val = TestEnumWithDefault.WithoutValue;
        val.TryGetString(true, out string content);

        Assert.Equal("Default_Value", content);
    }
}