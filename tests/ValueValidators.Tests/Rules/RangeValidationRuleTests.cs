using System;
using FluentAssertions;
using NUnit.Framework;
using WD.ValueValidators.Rules;
using WD.ValueValidators.Tests.TestMocks;

namespace WD.ValueValidators.Tests.Rules
{
    [TestFixture]
    public class RangeValidationRuleTests
    {
        private const string _ERROR_MESSAGE = "Error";

        [Test]
        public void Ctor_WithNullMaxValue_Throws()
        {
            // Arrange
            var sutAction = new Action(() =>
                new RangeValidationRule<string>(_ERROR_MESSAGE, _ERROR_MESSAGE, null, nullIsValid: false));

            // Act / Assert
            sutAction.Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("maxValue");
        }

        [Test]
        public void Ctor_WithNullMinValue_Throws()
        {
            // Arrange
            var sutAction = new Action(() =>
                new RangeValidationRule<string>(_ERROR_MESSAGE, null, _ERROR_MESSAGE, nullIsValid: false));

            // Act / Assert
            sutAction.Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("minValue");
        }

        [Test]
        public void Validate_WithNullValue_NotValid()
        {
            // Arrange
            var sut = new RangeValidationRule<string>(_ERROR_MESSAGE, "0", "100", nullIsValid: false);

            // Act
            var result = sut.Validate(null);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void Validate_WithAllowedNullValue_Valid()
        {
            // Arrange
            var sut = new RangeValidationRule<string>(_ERROR_MESSAGE, "0", "100");

            // Act
            var result = sut.Validate(null);

            // Assert
            result.Should().BeTrue();
        }

        [TestCase(10, 0, 100, true)]
        [TestCase(0, 0, 100, true)]
        [TestCase(100, 0, 100, true)]
        [TestCase(-1, 0, 100, false)]
        [TestCase(101, 0, 100, false)]
        public void Validate_WithTestClass(int value, int minValue, int maxValue, bool expected)
        {
            // Arrange
            var sut = new RangeValidationRule<RangeTestClass>(_ERROR_MESSAGE, new RangeTestClass(minValue), new RangeTestClass(maxValue));

            // Act
            var result = sut.Validate(new RangeTestClass(value));

            // Assert
            result.Should().Be(expected);
        }
    }
}