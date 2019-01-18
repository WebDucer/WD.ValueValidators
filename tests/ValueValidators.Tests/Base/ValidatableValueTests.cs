using FluentAssertions;
using NUnit.Framework;
using System;
using WD.ValueValidators.Base;
using WD.ValueValidators.Rules;

namespace WD.ValueValidators.Tests.Base
{
    [TestFixture]
    public class ValidatableValueTests
    {
        private const string _ERROR_MESSAGE = "Error";

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("test")]
        public void WithoutRules_IsAlwaysValid(string value)
        {
            // Arrange
            var sut = new ValidatableValue<string>();

            // Act
            sut.Value = value;

            // Assert
            sut.IsValid.Should().BeTrue();
            sut.IsNotValid.Should().BeFalse();
            sut.FirstError.Should().Be(" ");
            sut.Errors.Should().BeEmpty();
        }

        [TestCase(null, null)]
        [TestCase(null, "")]
        [TestCase("", null)]
        [TestCase(" ", "test")]
        [TestCase("test", null)]
        [TestCase("test", "test")]
        [TestCase("test", "test 2")]
        public void SetValue_SetNewValue(string startValue, string newValue)
        {
            // Arrange
            var sut = new ValidatableValue<string> { Value = startValue };

            // Act
            sut.Value = newValue;

            // Assert
            sut.Value.Should().Be(newValue);
        }

        [Test]
        public void IsValidChangedEventRaised_OnIsValidChange()
        {
            // Arrange
            var startValue = "123456";
            var sut = new ValidatableValue<string>
            {
                Value = startValue,
                ValidationRules = new IValidationRule<string>[]
                {
                    new StringLengthValidationRule("Length Error", 2, false, true),
                    new StringLengthValidationRule(_ERROR_MESSAGE, 5)
                }
            };

            // Act
            sut.IsValid.Should().BeTrue();
            sut.IsNotValid.Should().BeFalse();
            using (FluentAssertions.Events.IMonitor<ValidatableValue<string>> monitor = sut.Monitor())
            {
                sut.RaiseValidation();

                // Assert
                monitor.Should().Raise(nameof(ValidatableValue<string>.IsValidChanged))
                    .WithSender(sut)
                    .WithArgs<IsValidEventArgs>(t => t.IsValid == false);
            }
        }

        [Test]
        public void RaiseValidation_ValidateCurrentValue()
        {
            // Arrange
            var startValue = "123456";
            var sut = new ValidatableValue<string>
            {
                Value = startValue,
                ValidationRules = new IValidationRule<string>[]
                {
                    new StringLengthValidationRule("Length Error", 2, false, true),
                    new StringLengthValidationRule(_ERROR_MESSAGE, 5)
                }
            };

            // Act
            sut.IsValid.Should().BeTrue();
            sut.IsNotValid.Should().BeFalse();
            sut.RaiseValidation();

            // Assert
            sut.IsValid.Should().BeFalse();
            sut.IsNotValid.Should().BeTrue();
        }

        [Test]
        public void SetValue_WithDifferentValue_TriggerPropertyChanged()
        {
            // Arrange
            var value1 = Guid.NewGuid().ToString();
            var value2 = Guid.NewGuid().ToString();
            var sut = new ValidatableValue<string> { Value = value1 };

            // Act
            using (FluentAssertions.Events.IMonitor<ValidatableValue<string>> monitor = sut.Monitor())
            {
                sut.Value = value2;

                // Assert
                monitor.Should().RaisePropertyChangeFor(t => t.Value);
            }
        }

        [Test]
        public void SetValue_WithOneRule_AndInvalidValue_NotRaiseIfIsValidNotChanged()
        {
            // Arrange
            var startValue = "123456";
            var value = "123";
            var value2 = "1234";
            var sut = new ValidatableValue<string>
            {
                ValidationRules = new IValidationRule<string>[]
                {
                    new StringLengthValidationRule(_ERROR_MESSAGE, 5)
                },
                Value = startValue
            };

            // Act
            sut.Value = value;
            using (FluentAssertions.Events.IMonitor<ValidatableValue<string>> monitor = sut.Monitor())
            {
                sut.Value = value2;

                // Assert
                monitor.Should().RaisePropertyChangeFor(t => t.Value);
                monitor.Should().NotRaisePropertyChangeFor(t => t.Errors);
                monitor.Should().NotRaisePropertyChangeFor(t => t.FirstError);
                monitor.Should().NotRaisePropertyChangeFor(t => t.IsValid);
                monitor.Should().NotRaisePropertyChangeFor(t => t.IsNotValid);
            }
        }

        [Test]
        public void SetValue_WithOneRule_AndInvalidValue_OneError()
        {
            // Arrange
            var startValue = "Not empty";
            string value = null;
            var sut = new ValidatableValue<string>
            {
                ValidationRules = new IValidationRule<string>[]
                {
                    new NullValidationRule<string>(_ERROR_MESSAGE)
                },
                Value = startValue
            };

            // Act
            sut.Value = value;

            // Assert
            sut.IsValid.Should().BeFalse();
            sut.IsNotValid.Should().BeTrue();
            sut.FirstError.Should().Be(_ERROR_MESSAGE);
            sut.Errors.Should().HaveCount(1);
        }

        [Test]
        public void SetValue_WithOneRule_AndInvalidValue_RaiseChanges()
        {
            // Arrange
            var startValue = "Not empty";
            string value = null;
            var sut = new ValidatableValue<string>
            {
                ValidationRules = new IValidationRule<string>[]
                {
                    new NullValidationRule<string>(_ERROR_MESSAGE)
                },
                Value = startValue
            };

            // Act
            using (FluentAssertions.Events.IMonitor<ValidatableValue<string>> monitor = sut.Monitor())
            {
                sut.Value = value;

                // Assert
                monitor.Should().RaisePropertyChangeFor(t => t.Value);
                monitor.Should().RaisePropertyChangeFor(t => t.Errors);
                monitor.Should().RaisePropertyChangeFor(t => t.FirstError);
                monitor.Should().RaisePropertyChangeFor(t => t.IsValid);
                monitor.Should().RaisePropertyChangeFor(t => t.IsNotValid);
            }
        }

        [Test]
        public void SetValue_WithOneRule_AndValidValue_NoErrors()
        {
            // Arrange
            var value = "Not empty";
            var sut = new ValidatableValue<string>
            {
                ValidationRules = new IValidationRule<string>[] { new NullValidationRule<string>(_ERROR_MESSAGE) },
                Value = value
            };

            // Act

            // Assert
            sut.IsValid.Should().BeTrue();
            sut.IsNotValid.Should().BeFalse();
            sut.FirstError.Should().Be(" ");
            sut.Errors.Should().BeEmpty();
        }

        [Test]
        public void SetValue_WithTwoRule_AndInvalidValue_NotRaiseIfIsValidNotChanged()
        {
            // Arrange
            var startValue = "1234"; // valid
            var value = "1"; // invalid rule 1
            var value2 = "123456"; // invalid rule 2
            var sut = new ValidatableValue<string>
            {
                ValidationRules = new IValidationRule<string>[]
                {
                    new StringLengthValidationRule("Length Error", 2, false, true),
                    new StringLengthValidationRule(_ERROR_MESSAGE, 5)
                },
                Value = startValue
            };

            // Act
            sut.Value = value;
            using (FluentAssertions.Events.IMonitor<ValidatableValue<string>> monitor = sut.Monitor())
            {
                sut.Value = value2;

                // Assert
                monitor.Should().RaisePropertyChangeFor(t => t.Value);
                monitor.Should().RaisePropertyChangeFor(t => t.Errors);
                monitor.Should().RaisePropertyChangeFor(t => t.FirstError);
                monitor.Should().NotRaisePropertyChangeFor(t => t.IsValid);
                monitor.Should().NotRaisePropertyChangeFor(t => t.IsNotValid);
            }
        }
    }
}