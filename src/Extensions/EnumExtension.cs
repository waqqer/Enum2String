namespace Enum2String;

public static class EnumExtension
{
    extension(Enum value)
    {
        public string GetString()
            => ValueValidator.GetDefaultOrCustomValue(value);

        public bool HasCustomString()
            => ValueValidator.CustomValueExists(value);
        
        public bool TryGetString(out string val)
            => ValueValidator.TryGetCustomValue(value, out val);
    }
}