namespace Enum2String;

public static class EnumExtension
{
    extension(Enum value)
    {
        public string GetString(bool IncludeDefault = true)
        {
            if(IncludeDefault)
                return ValueValidator.GetDefaultOrCustomValue(value);
            return ValueValidator.GetCustomValue(value);
        }

        public bool HasCustomString(bool IncludeDefault = false)
        {
            if(IncludeDefault)
                return ValueValidator.CustomValueExistsWithDefault(value);
            return ValueValidator.CustomValueExists(value);
        }

        public bool HasString(bool IncludeDefault = false)
        {
            if(IncludeDefault)
                return ValueValidator.CustomValueExistsWithDefault(value);
            return ValueValidator.CustomValueExists(value);
        }

        public bool TryGetString(out string val)
            => ValueValidator.TryGetCustomValue(value, out val);

        public bool TryGetString(bool IncludeDefault, out string val)
        {
            if(IncludeDefault)
                return ValueValidator.TryGetDefaultOrCustomValue(value, out val);
            return ValueValidator.TryGetCustomValue(value, out val);
        }
    }
}