namespace WD.ValueValidators.Rules
{
    /// <summary>
    /// Valida the phone number.
    /// Allowed separators are " ", "-", ".", "()"
    /// </summary>
    public class PhoneNumberValidationRule : RegexValidationRule
    {
        private const string _PHONE_PATTERN = @"^(\+|\d|\(){1}(\d)+([\ |\(|\)|\-|\.])?(\d){0,}([\ |\(|\)|\-|\.])?(\d){0,}([\ |\(|\)|\-|\.])?(\d){0,}([\ |\(|\)|\-|\.])?(\d){0,}([\ |\(|\)|\-|\.])?(\d){0,}$";

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        /// <param name="invert">Invert the result (default: false)</param>
        /// <param name="nullOrEmptyIsValid">Null value is a valid value (default: false)</param>
        public PhoneNumberValidationRule(string errorMessage, bool nullOrEmptyIsValid = false, bool invert = false) :
            base(errorMessage, _PHONE_PATTERN, nullOrEmptyIsValid, invert)
        {
        }
    }
}