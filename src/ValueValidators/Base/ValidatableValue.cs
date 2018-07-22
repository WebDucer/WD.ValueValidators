using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WD.ValueValidators.Base
{
    /// <summary>
    ///     Validatable value implementation, with INotifyPropertyChange to detect value changes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValidatableValue<T> : IValidatableValue<T>, INotifyPropertyChanged
    {
        #region Constants

        private const string _NO_ERROR = " ";
        #endregion
        #region Properties

        /// <summary>
        ///     Collection of validation rules for this value
        /// </summary>
        public IList<IValidationRule<T>> ValidationRules { get; set; } = new List<IValidationRule<T>>();

        #endregion

        #region Validation

        /// <summary>
        ///     Validate the value with validation rules
        /// </summary>
        /// <param name="value"></param>
        protected virtual void ValidateValue(T value)
        {
            var oldIsValid = IsValid;

            var errors = ValidationRules
                .Where(w => !w.Validate(value))
                .Select(s => s.ErrorMessage).ToArray();

            if (Errors?.SequenceEqual(errors) == true)
            {
                return;
            }

            Errors = errors;
            RaisePropertyChanged(nameof(Errors));
            RaisePropertyChanged(nameof(FirstError));

            var isValid = IsValid;

            if (oldIsValid == isValid)
            {
                return;
            }

            RaisePropertyChanged(nameof(IsValid));
            RaiseIsValidChaged(isValid);
        }

        #endregion

        #region Implementation of IValidatable

        /// <inheritdoc />
        public string FirstError
        {
            get
            {
                var firstError =Errors?.FirstOrDefault();
                return string.IsNullOrEmpty(firstError) ? _NO_ERROR : firstError;
            }
        }

        /// <inheritdoc />
        public IEnumerable<string> Errors { get; private set; } = new string[0];

        /// <inheritdoc />
        public bool IsValid => Errors?.Any() == false;

        /// <inheritdoc />
        public void RaiseValidation()
        {
            ValidateValue(Value);
        }

        /// <inheritdoc />
        public event EventHandler<IsValidEventArgs> IsValidChanged;

        /// <summary>
        ///     Raise the is valid property changed
        /// </summary>
        /// <param name="isValid"></param>
        protected virtual void RaiseIsValidChaged(bool isValid)
        {
            IsValidChanged?.Invoke(this, new IsValidEventArgs(isValid));
        }

        #endregion

        #region Implementation of IValidatableValue<T>

        private T _value;

        /// <inheritdoc />
        public T Value
        {
            get => _value;
            set
            {
                if (EqualityComparer<T>.Default.Equals(_value, value))
                {
                    return;
                }

                _value = value;
                RaisePropertyChanged();
                ValidateValue(value);
            }
        }

        #endregion

        #region Implementation of INotifyPropertyChanged

        /// <summary>
        ///     Property Changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Raise the property change event
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}