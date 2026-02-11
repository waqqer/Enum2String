namespace Enum2String;

internal static class ValueReplacer
{
    public static string GetValueByReplaceOption(in DefaultStringValueAttribute attribute, string replacing_value)
    {
        if(attribute.option == ValueReplaceOption.None)
            return attribute.Value;
        
        string result = attribute.Value.Replace("{Value}", replacing_value);
        return result;
    }
}