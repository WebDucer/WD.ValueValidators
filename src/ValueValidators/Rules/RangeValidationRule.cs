using System;

namespace WD.ValueValidators.Rules
{
    /// <summary>
    ///     Check, if the value is in Range
    /// </summary>
    /// <typeparam name="T">Type to compare (have to implement <see cref="IComparable" />)</typeparam>
    public class RangeValidationRule<T> : RangeValidationRuleBase<T> where T : class, IComparable<T>
    {
        private readonly bool _nullIsValid;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        /// <param name="minValue">Min value to compare with</param>
        /// <param name="maxValue">max value to compre with</param>
        /// <param name="maxValueAllowerd">Is value == MaxValue valid (default: true)</param>
        /// <param name="minValueAllowed">Is value == MinValue valid (default: true)</param>
        /// <param name="nullIsValid">NULL is valid value</param>
        public RangeValidationRule(string errorMessage, T minValue, T maxValue, bool maxValueAllowerd = true,
            bool minValueAllowed = true, bool nullIsValid = true)
            : this(errorMessage, null, minValue, maxValue, maxValueAllowerd, minValueAllowed, nullIsValid)
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="minErrorMessage">Error message if value is lower than min value</param>
        /// <param name="maxErrorMessage">Error message if value is higher than max value</param>
        /// <param name="minValue">Min value to compare with</param>
        /// <param name="maxValue">max value to compre with</param>
        /// <param name="maxValueAllowerd">Is value == MaxValue valid (default: true)</param>
        /// <param name="minValueAllowed">Is value == MinValue valid (default: true)</param>
        /// <param name="nullIsValid">NULL on reference types and default(T) on value types are valid values</param>
        public RangeValidationRule(string minErrorMessage, string maxErrorMessage, T minValue, T maxValue,
            bool minValueAllowed = true, bool maxValueAllowerd = true, bool nullIsValid = true)
            : base(minErrorMessage, maxErrorMessage, minValue, maxValue, minValueAllowed, maxValueAllowerd,
                () => PreconditionChecks(minValue, maxValue))
        {
            _nullIsValid = nullIsValid;
        }

        /// <inheritdoc />
        protected override bool ValueAlwayValid(T value)
        {
            if (_nullIsValid && value == null)
            {
                return true;
            }

            return false;
        }

        private static void PreconditionChecks(T minValue, T maxValue)
        {
            if (minValue == null)
            {
                throw new ArgumentNullException(nameof(minValue));
            }

            if (maxValue == null)
            {
                throw new ArgumentNullException(nameof(maxValue));
            }
        }

        #region Implementation of IValidationRule<in T>

        #endregion
    }
}