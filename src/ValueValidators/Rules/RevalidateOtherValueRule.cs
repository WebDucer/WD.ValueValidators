using WD.ValueValidators.Base;

namespace WD.ValueValidators.Rules
{
    /// <summary>
    ///     Rule tot trigger the validation of another validatable value
    /// </summary>
    /// <typeparam name="T">Value type</typeparam>
    public class RevalidateOtherValueRule<T> : IValidationRule<T>
    {
        private readonly IValidatableValue<T> _value;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="value">Value to refresh validation</param>
        public RevalidateOtherValueRule(IValidatableValue<T> value)
        {
            _value = value;
        }

        #region Implementation of IValidationRule<in T>

        /// <inheritdoc />
        public bool Validate(T value)
        {
            _value.RaiseValidation();
            return true;
        }

        /// <inheritdoc />
        public string ErrorMessage { get; } = string.Empty;

        #endregion
    }
}