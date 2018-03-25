using System;
using WD.ValueValidators.Base;

namespace WD.ValueValidators.Rules
{
    /// <summary>
    ///     Rule to check the string length (min or max)
    /// </summary>
    public class StringLengthValidationRule : IValidationRule<string>
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        /// <param name="checkMaxLength">Check max or min length (default: true - max length)</param>
        /// <param name="nullIsValid">Treat NULL as valid value</param>
        /// <param name="length">The Length to check against</param>
        public StringLengthValidationRule(string errorMessage, int length, bool checkMaxLength = true,
            bool nullIsValid = false)
        {
            if (length < 0)
            {
                throw new ArgumentException("Length have to be positive", nameof(length));
            }

            ErrorMessage = errorMessage;
            Length = length;
            CheckMaxLength = checkMaxLength;
            NullIsValid = nullIsValid;
        }

        /// <summary>
        ///     Check max or min length
        /// </summary>
        public bool CheckMaxLength { get; }

        /// <summary>
        ///     Treat NULL as valid value
        /// </summary>
        public bool NullIsValid { get; }

        /// <summary>
        ///     The Length to check against
        /// </summary>
        public int Length { get; }

        #region Implementation of IValidationRule<in int>

        /// <inheritdoc />
        public string ErrorMessage { get; }

        /// <inheritdoc />
        public bool Validate(string value)
        {
            if (NullIsValid && value == null)
            {
                return true;
            }

            if (value == null)
            {
                return false;
            }

            if (CheckMaxLength)
            {
                return value.Length <= Length;
            }

            return value.Length >= Length;
        }

        #endregion
    }
}