namespace Enum2String.Tests;

public class BasicMappingTest
{
    [Fact]
    public void TestDefaultValue()
    {
        TestingEnum_1_WithDefault val1 = TestingEnum_1_WithDefault.Blue;
        Assert.Equal("SomeColor", val1.GetString());
    }

    [Fact]
    public void TestFieldValue()
    {
        TestingEnum_1_WithDefault val1 = TestingEnum_1_WithDefault.White;
        Assert.Equal("White_Color", val1.GetString());
    }

    [Fact]
    public void TestNonFieldValue()
    {
        TestingEnum_1_WithoutDefault val1 = TestingEnum_1_WithoutDefault.Blue;
        Assert.Equal("Blue", val1.GetString());
    }
}

[DefaultStringValue("SomeColor")]
public enum TestingEnum_1_WithDefault
{
    [StringValue("Black_Color")]
    Black,
    [StringValue("White_Color")]
    White,
    Blue
}

public enum TestingEnum_1_WithoutDefault
{
    [StringValue("Black_Color")]
    Black,
    [StringValue("White_Color")]
    White,
    Blue
}
