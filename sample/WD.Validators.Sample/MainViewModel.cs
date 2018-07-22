using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WD.ValueValidators.Base;
using WD.ValueValidators.Rules;

namespace WD.Validators.Sample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Constructor

        public MainViewModel()
        {
            // Init validatable values
            ContainsString = new ValidatableValue<string>
            {
                ValidationRules = new IValidationRule<string>[]
                {
                    new ContainsValidationRule<string>("Unknown value", new[] {"test", "example", "fake"})
                }
            };
            ContainsString.RaiseValidation();
            NotContainsString = new ValidatableValue<string>
            {
                ValidationRules = new IValidationRule<string>[]
                {
                    new ContainsValidationRule<string>("Value already exists", new[] {"test", "example", "fake"}, true)
                }
            };
            NotContainsString.RaiseValidation();
            ContainsInteger = new ValidatableValue<int>
            {
                ValidationRules = new IValidationRule<int>[]
                {
                    new ContainsValidationRule<int>("Unknown value", new[] {5, 12, 25})
                }
            };
            ContainsString.RaiseValidation();
            Email = new ValidatableValue<string>
            {
                ValidationRules = new IValidationRule<string>[]
                {
                    new EmailValidationRule("Not valid email address", true)
                }
            };
            Email.RaiseValidation();
            EqualsValue = new ValidatableValue<string>
            {
                ValidationRules = new IValidationRule<string>[]
                {
                    new EqualValuesValidationRule<string>("Values are not equal", () => Email.Value) 
                }
            };
            EqualsValue.RaiseValidation();
            NullValue = new ValidatableValue<ValueHolder>
            {
                ValidationRules = new IValidationRule<ValueHolder>[]
                {
                    new NullValidationRule<ValueHolder>("Value is null")
                }
            };
            NullValue.RaiseValidation();

            // Values
            Values = new[]
            {
                null,
                new ValueHolder {Id = 1, DislayValue = "Value 1"},
                new ValueHolder {Id = 2, DislayValue = "Value 2"},
                new ValueHolder {Id = 3, DislayValue = "Value 3"},
            };
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Properties

        public ValueHolder[] Values { get; }

        public ValidatableValue<string> ContainsString { get; }
        public ValidatableValue<string> NotContainsString { get; }
        public ValidatableValue<int> ContainsInteger { get; }
        public ValidatableValue<string> Email { get; }
        public ValidatableValue<string> EqualsValue { get; }
        public ValidatableValue<ValueHolder> NullValue { get; }

        #endregion
    }
}