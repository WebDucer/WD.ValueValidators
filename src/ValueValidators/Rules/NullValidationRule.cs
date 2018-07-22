using WD.ValueValidators.Base;

namespace WD.ValueValidators.Rules
{
    /// <summary>
    ///     Rule for null value validation
    /// </summary>
    /// <typeparam name="T">Nullable type of the value</typeparam>
    public class NullValidationRule<T> : IValidationRule<T> where T : class
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        /// <param name="invert">Invert (default: false)</param>
        public NullValidationRule(string errorMessage, bool invert = false)
        {
            ErrorMessage = errorMessage;
            Invert = invert;
        }

        /// <summary>
        ///     Invert the result (true: Non null value is error)
        /// </summary>
        public bool Invert { get; }

        #region Internal

        private bool InternalValidate(T value)
        {
            return value != null;
        }

        #endregion

        #region Implementation of IValidationRule<in T>

        /// <inheritdoc />
        public string ErrorMessage { get; }

        /// <inheritdoc />
        public bool Validate(T value)
        {
            return Invert
                ? !InternalValidate(value)
                : InternalValidate(value);
        }

        #endregion
    }
}