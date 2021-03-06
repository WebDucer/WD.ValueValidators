﻿using System;
using WD.ValueValidators.Base;

namespace WD.ValueValidators.Rules
{
    /// <summary>
    ///     Checks, if the value is greater than a given value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GreaterThanValidationRule<T> : IValidationRule<T> where T : struct, IComparable
    {
        private readonly ValidatableValue<T> _compareValue;
        private readonly bool _equalIsValid;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="compareValue">Value to compare against</param>
        /// <param name="equalIsValid">Equal values are valid (default: false)</param>
        public GreaterThanValidationRule(string errorMessage, ValidatableValue<T> compareValue, bool equalIsValid = false)
        {
            _compareValue = compareValue ?? throw new ArgumentNullException(nameof(compareValue));
            _equalIsValid = equalIsValid;
            ErrorMessage = errorMessage;
        }

        #region Implementation of IValidationRule<in decimal>

        /// <inheritdoc />
        public bool Validate(T value)
        {
            return _equalIsValid
                ? value.CompareTo(_compareValue.Value) >= 0
                : value.CompareTo(_compareValue.Value) > 0;
        }

        /// <inheritdoc />
        public string ErrorMessage { get; }

        #endregion
    }
}