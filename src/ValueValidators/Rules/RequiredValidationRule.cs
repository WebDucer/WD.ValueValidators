using WD.ValueValidators.Base;

namespace WD.ValueValidators.Rules
{
    /// <summary>
    ///     Validates, if the value is required or not
    /// </summary>
    public class RequiredValidationRule : IValidationRule<string>
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        /// <param name="allowWitheSpaces">Treat whitespaces as valid values (default: false)</param>
        public RequiredValidationRule(string errorMessage, bool allowWitheSpaces = false)
        {
            ErrorMessage = errorMessage;
            AllowWhiteSpaces = allowWitheSpaces;
        }

        /// <summary>
        ///     Treat whitespaces as valid values (default: false)
        /// </summary>
        public bool AllowWhiteSpaces { get; }

        #region Implementation of IValidationRule<in T>

        /// <inheritdoc />
        public string ErrorMessage { get; }

        /// <inheritdoc />
        public bool Validate(string value)
        {
            return AllowWhiteSpaces
                ? !string.IsNullOrEmpty(value)
                : !string.IsNullOrWhiteSpace(value);
        }

        #endregion
    }
}