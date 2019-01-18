using System;
using FluentAssertions;
using NUnit.Framework;
using WD.ValueValidators.Base;
using WD.ValueValidators.Rules;
using static WD.ValueValidators.Tests.Constants;


namespace WD.ValueValidators.Tests.Rules
{
    [TestFixture]
    public class GreaterThanRuleValidationTests
    {
        [Test]
        public void Constructor_WithNullValue_Throws()
        {
            // Arrange
            var sutAction = new Action(() => new GreaterThanValidationRule<int>(ERROR_MESSAGE, null));

            // Act / Assert
            sutAction.Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("compareValue");
        }

        [Theory]
        [TestCase(13, 11, 12)]
        [TestCase(200, -100, 100)]
        [TestCase(100, 99, 100)]
        public void Validate_WithHigher_IsValid(int initValue, int newValue, int current)
        {
            // Arrange
            var compareValue = new ValidatableValue<int>
            {
                Value = initValue
            };
            var sut = new GreaterThanValidationRule<int>(ERROR_MESSAGE, compareValue);
            sut.Validate(current).Should().BeFalse();

            // Act
            compareValue.Value = newValue;
            var result = sut.Validate(current);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [TestCase(13, 12, 12)]
        [TestCase(200, 100, 100)]
        public void Validate_WithEqual_IsValid(int initValue, int newValue, int current)
        {
            // Arrange
            var compareValue = new ValidatableValue<int>
            {
                Value = initValue
            };
            var sut = new GreaterThanValidationRule<int>(ERROR_MESSAGE, compareValue, true);
            sut.Validate(current).Should().BeFalse();

            // Act
            compareValue.Value = newValue;
            var result = sut.Validate(current);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [TestCase(11, 13, 12)]
        [TestCase(-100, 200, 100)]
        [TestCase(99, 100, 100)]
        public void Validate_WithLower_IsNotValid(int initValue, int newValue, int current)
        {
            // Arrange
            var compareValue = new ValidatableValue<int>
            {
                Value = initValue
            };
            var sut = new GreaterThanValidationRule<int>(ERROR_MESSAGE, compareValue);
            sut.Validate(current).Should().BeTrue();

            // Act
            compareValue.Value = newValue;
            var result = sut.Validate(current);

            // Assert
            result.Should().BeFalse();
        }
    }
}
