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

            PhoneNumber = new ValidatableValue<string>
            {
                ValidationRules = new IValidationRule<string>[]
                {
                    new PhoneNumberValidationRule("Not valid phone number")
                }
            };
            PhoneNumber.RaiseValidation();

            IntRange = new ValidatableValue<int>
            {
                ValidationRules = new IValidationRule<int>[]
                {
                    new PrimitiveRangeValidationRule<int>("Value should be between 10 and 50", 10, 50)
                }
            };
            IntRange.RaiseValidation();

            RegexValue = new ValidatableValue<string>
            {
                ValidationRules = new IValidationRule<string>[]
                {
                    new RegexValidationRule("Allowed format: dd.MM.yyyy", @"^\d{2}\.\d{2}\.\d{4}$")
                }
            };
            RegexValue.RaiseValidation();

            MixedString = new ValidatableValue<string>
            {
                ValidationRules = new IValidationRule<string>[]
                {
                    new RequiredValidationRule("Required!"),
                    new StringLengthValidationRule("Password should have at least 8 characters!", 8, false),
                    new StringLengthValidationRule("Password should have at maximum 32 characters!", 32)
                }
            };
            MixedString.RaiseValidation();

            // Values
            Values = new[]
            {
                null,
                new ValueHolder {Id = 1, DislayValue = "Value 1"},
                new ValueHolder {Id = 2, DislayValue = "Value 2"},
                new ValueHolder {Id = 3, DislayValue = "Value 3"}
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
        public ValidatableValue<string> PhoneNumber { get; }
        public ValidatableValue<int> IntRange { get; }
        public ValidatableValue<string> RegexValue { get; }
        public ValidatableValue<string> MixedString { get; }

        #endregion
    }
}