namespace Enum2String;

public static class EnumExtension
{
    extension(Enum value)
    {
        public string GetString()
            => ValueValidator.GetDefaultOrCustomValue(value);

        public bool HasCustomString(bool IncludeDefault = false)
        {
            if(IncludeDefault)
                return ValueValidator.CustomValueExistsWithDefault(value);
            return ValueValidator.CustomValueExists(value);
        }

        public bool TryGetString(out string val)
            => ValueValidator.TryGetDefaultOrCustomValue(value, out val);
    }
}