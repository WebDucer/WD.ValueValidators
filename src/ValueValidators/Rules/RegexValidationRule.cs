using System;
using System.Text.RegularExpressions;
using WD.ValueValidators.Base;

namespace WD.ValueValidators.Rules
{
    /// <summary>
    ///     Rule for regular expression validation
    /// </summary>
    public class RegexValidationRule : IValidationRule<string>
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        /// <param name="expression">Regular expression for validation</param>
        /// <param name="invert">Invert the result (default: false)</param>
        /// <param name="nullOrEmptyIsValid">Null value is a valid value (default: false)</param>
        public RegexValidationRule(string errorMessage, Regex expression, bool nullOrEmptyIsValid = false, bool invert = false)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            ErrorMessage = errorMessage;
            Invert = invert;
            NullOrEmptyIsValid = nullOrEmptyIsValid;
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        /// <param name="expressionPattern">Regular expression pattern for validation</param>
        /// <param name="invert">Invert the result</param>
        /// <param name="nullOrEmptyIsValid">Null value is a valid value (default: false)</param>
        public RegexValidationRule(string errorMessage, string expressionPattern, bool nullOrEmptyIsValid = false, bool invert = false) : this(
            errorMessage, new Regex(expressionPattern), nullOrEmptyIsValid, invert)
        {
        }

        /// <summary>
        ///     Invert the result (true: Non null value is error)
        /// </summary>
        public bool Invert { get; }

        /// <summary>
        ///     Regular expression to check against
        /// </summary>
        public Regex Expression { get; }

        /// <summary>
        ///     Treat NULL as valid value
        /// </summary>
        public bool NullOrEmptyIsValid { get; }

        private bool ValidateInternal(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return NullOrEmptyIsValid;
            }

            return Expression.IsMatch(value);
        }

        #region Implementation of IValidationRule<in string>

        /// <inheritdoc />
        public string ErrorMessage { get; }

        /// <inheritdoc />
        public bool Validate(string value)
        {
            return Invert
                ? !ValidateInternal(value)
                : ValidateInternal(value);
        }

        #endregion
    }
}