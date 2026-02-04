namespace Enum2String;

/// <summary>
/// Enum extension with methods for works with string representation
/// </summary>
public static class EnumExtension
{
    /// <summary>
    /// Enum extension with methods for works with string representation
    /// </summary>
    /// <param name="value">Enum value</param>
    extension(Enum value)
    {
        /// <summary>
        /// Get enum string value representation
        /// 
        /// <para>
        ///       <see cref="DefaultStringValueAttribute"/>
        ///       <br/>
        ///       <see cref="StringValueAttribute"/>
        ///       <br/>
        ///       <see cref="IValueRepresent"/>
        /// </para>
        /// </summary>
        /// <returns>Enum string representation</returns>
        public string GetString()
            => ValueValidator.GetDefaultOrCustomValue(value);

        /// <summary>
        /// Return if enum value has string representation
        /// </summary>
        /// <returns>
        ///       True - value has string representation. (Doesn`t Default value); 
        ///       False - Doesn't have string representation
        /// </returns>
        public bool HasCustomString()
            => ValueValidator.CustomValueExists(value);

        /// <summary>
        /// Return if enum value has string representation
        /// <br/>
        /// Analogue <see cref="HasCustomString"/>
        /// </summary>
        /// <returns>
        ///       True - value has string representation. (Doesn`t Default value); 
        ///       False - Doesn't have string representation
        /// </returns>
        public bool HasString()
            => ValueValidator.CustomValueExists(value);
        
        /// <summary>
        /// Return if enum value has string representation and <br/>
        /// setting value to enum value string representation
        /// </summary>
        /// <param name="val">Enum value string representation or Default value</param>
        /// <returns>
        ///       True - value has string representation. (Doesn`t Default value); 
        ///       False - Doesn't have string representation
        /// </returns>
        public bool TryGetString(out string val)
            => ValueValidator.TryGetCustomValue(value, out val);
    }
}