using System;
using System.Collections.Generic;
using WD.ValueValidators.Base;

namespace WD.ValueValidators.Rules
{
    /// <inheritdoc />
    public class EqualValuesValidationRule<T> : IValidationRule<T>
    {
        private readonly Func<T> _valueToCompare;

        /// <inheritdoc />
        public EqualValuesValidationRule(string errorMessage, Func<T> valueToCompare)
        {
            _valueToCompare = valueToCompare;
            ErrorMessage = errorMessage;
        }

        /// <inheritdoc />
        public EqualValuesValidationRule(string errorMessage, T valueToCompare) : this(errorMessage,
            () => valueToCompare)
        {
        }

        #region Implementation of IValidationRule<in T>

        /// <inheritdoc />
        public string ErrorMessage { get; }

        /// <inheritdoc />
        public bool Validate(T value)
        {
            return EqualityComparer<T>.Default.Equals(value, _valueToCompare());
        }

        #endregion
    }
}