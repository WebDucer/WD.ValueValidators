namespace WD.ValueValidators.Base
{
    /// <summary>
    ///     Validation rule
    /// </summary>
    /// <typeparam name="T">Type of value to validate</typeparam>
    public interface IValidationRule<in T>
    {
        /// <summary>
        ///     Error message, if the validation fails
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        ///     Validate the given value
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <returns>Validation state</returns>
        bool Validate(T value);
    }
}