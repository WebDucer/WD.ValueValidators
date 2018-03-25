using System;
using FluentAssertions;
using NUnit.Framework;
using WD.ValueValidators.Rules;

namespace WD.ValueValidators.Tests.Rules
{
    [TestFixture]
    public class EqualValuesValidationRuleTests
    {
        private const string _ERROR_MESSAGE = "Error";

        [TestCase("", "", true)]
        [TestCase("Hallo", "", false)]
        [TestCase("", "Hallo", false)]
        [TestCase("Hallo", "Hallo", true)]
        [TestCase(null, "", false)]
        [TestCase("", null, false)]
        [TestCase(null, null, true)]
        public void Validate_WithSringAsValue(string value, string compareValue, bool validationResult)
        {
            // Arrange
            var sut = new EqualValuesValidationRule<string>(_ERROR_MESSAGE, compareValue);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().Be(validationResult);
        }

        [TestCase("", "", true)]
        [TestCase("Hallo", "", false)]
        [TestCase("", "Hallo", false)]
        [TestCase("Hallo", "Hallo", true)]
        [TestCase(null, "", false)]
        [TestCase("", null, false)]
        [TestCase(null, null, true)]
        public void Validate_WithSringFunctionAsValue(string value, string compareValue, bool validationResult)
        {
            // Arrange
            var valueToComapre = new Func<string>(() => compareValue);
            var sut = new EqualValuesValidationRule<string>(_ERROR_MESSAGE, valueToComapre);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().Be(validationResult);
        }

        [TestCase(0, 0, true)]
        [TestCase(1, 0, false)]
        [TestCase(1, 0, false)]
        [TestCase(1000, 1000, true)]
        [TestCase(-1000, -1000, true)]
        [TestCase(int.MinValue, int.MinValue, true)]
        [TestCase(int.MaxValue, int.MaxValue, true)]
        public void Validate_WithIntegerAsValue(int value, int compareValue, bool validationResult)
        {
            // Arrange
            var sut = new EqualValuesValidationRule<int>(_ERROR_MESSAGE, compareValue);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().Be(validationResult);
        }

        [Test]
        public void Validate_WithErrorMessage_HasErrorMessage()
        {
            // Arrange
            var sut = new EqualValuesValidationRule<string>(_ERROR_MESSAGE, "1");

            // Act
            var result = sut.Validate("2");

            // Assert
            sut.ErrorMessage.Should().Be(_ERROR_MESSAGE);
        }
    }
}