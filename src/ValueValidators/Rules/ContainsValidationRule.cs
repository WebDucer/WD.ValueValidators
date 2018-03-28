using System;
using System.Collections.Generic;
using System.Linq;
using WD.ValueValidators.Base;

namespace WD.ValueValidators.Rules
{
    /// <summary>
    ///     Check, if the value is in the collection
    /// </summary>
    /// <typeparam name="T">Type of value</typeparam>
    public class ContainsValidationRule<T> : IValidationRule<T>
    {
        private readonly IEnumerable<T> _checkCollection;
        private readonly bool _invertResult;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        /// <param name="checkCollection">Collection for checking</param>
        /// <param name="invertResult">Should the validation result be inverted (default: false)</param>
        public ContainsValidationRule(string errorMessage, IEnumerable<T> checkCollection, bool invertResult = false)
        {
            _checkCollection = checkCollection ?? throw new ArgumentNullException(nameof(checkCollection),
                                   "Collection can not be null for comparisson");
            _invertResult = invertResult;
            ErrorMessage = errorMessage;
        }

        private bool ValidateIntern(T value)
        {
            return _checkCollection.Contains(value);
        }

        #region Implementation of IValidationRule<in T>

        /// <inheritdoc />
        public string ErrorMessage { get; }

        /// <inheritdoc />
        public bool Validate(T value)
        {
            return _invertResult
                ? !ValidateIntern(value)
                : ValidateIntern(value);
        }

        #endregion
    }
}