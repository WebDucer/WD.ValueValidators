namespace WD.ValueValidators.Rules
{
    /// <summary>
    ///     Validation rule to validate the email
    /// </summary>
    public class EmailValidationRule : RegexValidationRule
    {
        private const string _EMAIL_PATTERN = @"^[\w\.\-_]+@[\w\.\-_]+\.[\w]+$";

        /// <inheritdoc />
        public EmailValidationRule(string errorMessage, bool nullOrEmptyIsValid = false, bool invert = false) : base(
            errorMessage, _EMAIL_PATTERN, nullOrEmptyIsValid, invert)
        {
        }
    }
}