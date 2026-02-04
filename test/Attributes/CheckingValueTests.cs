namespace Enum2String.Tests;

public class CheckingValueTests
{
    [Fact]
    public void HasValue_Test()
    {
        TestEnum val = TestEnum.WithValue;
        bool has = val.HasCustomString(false);

        Assert.True(has);
    }

    [Fact]
    public void HasValueNull_Test()
    {
        TestEnum val = TestEnum.WithoutValue;
        bool has = val.HasCustomString(false);

        Assert.False(has);
    }

    [Fact]
    public void HasValueNull1_NoDefault_Test()
    {
        TestEnumWithDefault val = TestEnumWithDefault.WithoutValue;
        bool has = val.HasCustomString(false);

        Assert.False(has);
    }

    [Fact]
    public void HasValueNull2_NoDefault_Test()
    {
        TestEnum val = TestEnum.WithoutValue;
        bool has = val.HasCustomString(false);

        Assert.False(has);
    }

    [Fact]
    public void HasValue_WithDefault_Test()
    {
        TestEnumWithDefault val = TestEnumWithDefault.WithValue;
        bool has = val.HasCustomString(true);

        Assert.True(has);
    }

    [Fact]
    public void HasValueNull_WithDefault_Test()
    {
        TestEnumWithDefault val = TestEnumWithDefault.WithoutValue;
        bool has = val.HasCustomString(true);

        Assert.True(has);
    }
}