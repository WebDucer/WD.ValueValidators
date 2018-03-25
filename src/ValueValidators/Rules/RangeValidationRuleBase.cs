using System;
using WD.ValueValidators.Base;

namespace WD.ValueValidators.Rules
{
    /// <inheritdoc />
    public abstract class RangeValidationRuleBase<T> : IValidationRule<T> where T : IComparable<T>
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="minErrorMessage">Error message if value is lower than min value</param>
        /// <param name="maxErrorMessage">Error message if value is higher than max value</param>
        /// <param name="minValue">Min value to compare with</param>
        /// <param name="maxValue">max value to compre with</param>
        /// <param name="maxValueAllowerd">Is value == MaxValue valid (default: true)</param>
        /// <param name="minValueAllowed">Is value == MinValue valid (default: true)</param>
        /// <param name="preconditions">Checks from derived class</param>
        protected RangeValidationRuleBase(string minErrorMessage, string maxErrorMessage, T minValue, T maxValue,
            bool minValueAllowed = true, bool maxValueAllowerd = true, Action preconditions = null)
        {
            preconditions?.Invoke();

            if (minValue.CompareTo(maxValue) >= 0)
            {
                throw new ArgumentException($"{nameof(minValue)} should be smaller than {nameof(maxValue)}",
                    nameof(minValue));
            }

            ErrorMessage = minErrorMessage;
            MinErrorMessage = minErrorMessage;
            MaxErrorMessage = maxErrorMessage;

            MinValue = minValue;
            MaxValue = maxValue;
            MaxValueAllowerd = maxValueAllowerd;
            MinValueAllowed = minValueAllowed;
        }

        /// <summary>
        ///     Error message if value is lower than min value
        /// </summary>
        protected virtual string MaxErrorMessage { get; }

        /// <summary>
        ///     Error message if value is higher than max value
        /// </summary>
        protected virtual string MinErrorMessage { get; }

        /// <summary>
        ///     The upper value for comparison
        /// </summary>
        public virtual T MinValue { get; }

        /// <summary>
        ///     The lower value for comparison
        /// </summary>
        public virtual T MaxValue { get; }

        /// <summary>
        ///     Is value == MaxValue treated as valid
        /// </summary>
        public virtual bool MaxValueAllowerd { get; }

        /// <summary>
        ///     Is value == MinValue treated as valid
        /// </summary>
        public virtual bool MinValueAllowed { get; }

        /// <inheritdoc />
        public virtual string ErrorMessage { get; private set; }

        /// <inheritdoc />
        public virtual bool Validate(T value)
        {
            if (ValueAlwayValid(value))
            {
                return true;
            }

            if (!CheckUpper(value))
            {
                return false;
            }

            if (!CheckLower(value))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Check upper bounds
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns></returns>
        protected virtual bool CheckUpper(T value)
        {
            var isValid = MaxValueAllowerd
                ? MaxValue.CompareTo(value) >= 0
                : MaxValue.CompareTo(value) > 0;
            if (!isValid)
            {
                ErrorMessage = MaxErrorMessage ?? MinErrorMessage;
            }

            return isValid;
        }

        /// <summary>
        ///     Check lower bound
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns></returns>
        protected virtual bool CheckLower(T value)
        {
            var isValid = MinValueAllowed
                ? MinValue.CompareTo(value) <= 0
                : MinValue.CompareTo(value) < 0;

            if (!isValid)
            {
                ErrorMessage = MinErrorMessage ?? MaxErrorMessage;
            }

            return isValid;
        }

        /// <summary>
        ///     Is value valid
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>If true, no other checks will be made</returns>
        protected virtual bool ValueAlwayValid(T value)
        {
            return false;
        }
    }
}