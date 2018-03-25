using System;
using WD.ValueValidators.Base;

namespace WD.ValueValidators.Rules
{
    /// <inheritdoc />
    public class PrimitiveRangeValidationRule<T> : RangeValidationRuleBase<T> where T : struct, IComparable<T>
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        /// <param name="minValue">Min value to compare with</param>
        /// <param name="maxValue">max value to compre with</param>
        /// <param name="maxValueAllowerd">Is value == MaxValue valid (default: true)</param>
        /// <param name="minValueAllowed">Is value == MinValue valid (default: true)</param>
        public PrimitiveRangeValidationRule(string errorMessage, T minValue, T maxValue, bool maxValueAllowerd = true,
            bool minValueAllowed = true)
            : this(errorMessage, null, minValue, maxValue, minValueAllowed, maxValueAllowerd)
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
        public PrimitiveRangeValidationRule(string minErrorMessage, string maxErrorMessage, T minValue, T maxValue,
            bool minValueAllowed = true, bool maxValueAllowerd = true) : base(minErrorMessage, maxErrorMessage, minValue, maxValue, minValueAllowed, maxValueAllowerd)
        {
        }
    }
}