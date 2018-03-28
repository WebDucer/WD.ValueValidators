using System;
using FluentAssertions;
using NUnit.Framework;
using WD.ValueValidators.Rules;
using static WD.ValueValidators.Tests.Constants;

namespace WD.ValueValidators.Tests.Rules
{
    [TestFixture]
    public class PrimitiveRangeValidationRuleTests
    {
        [TestCase(10, 0, 100, true)]
        [TestCase(0, 0, 100, true)]
        [TestCase(100, 0, 100, true)]
        [TestCase(-1, 0, 100, false)]
        [TestCase(101, 0, 100, false)]
        public void Validate_WithIntegers(int value, int minValue, int maxValue, bool expected)
        {
            // Arrange
            var sut = new PrimitiveRangeValidationRule<int>(ERROR_MESSAGE, minValue, maxValue);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().Be(expected);
        }

        [TestCase(10, 0, 100, true)]
        [TestCase(0, 0, 100, true)]
        [TestCase(99, 0, 100, true)]
        [TestCase(100, 0, 100, false)]
        [TestCase(-1, 0, 100, false)]
        public void Validate_WithIntegers_MaxNotValid(int value, int minValue, int maxValue, bool expected)
        {
            // Arrange
            var sut = new PrimitiveRangeValidationRule<int>(ERROR_MESSAGE, minValue, maxValue, false);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().Be(expected);
        }

        [TestCase(10, 0, 100, true)]
        [TestCase(1, 0, 100, true)]
        [TestCase(0, 0, 100, false)]
        [TestCase(100, 0, 100, true)]
        [TestCase(-1, 0, 100, false)]
        [TestCase(101, 0, 100, false)]
        public void Validate_WithIntegers_MinNotValid(int value, int minValue, int maxValue, bool expected)
        {
            // Arrange
            var sut = new PrimitiveRangeValidationRule<int>(ERROR_MESSAGE, minValue, maxValue, minValueAllowed: false);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public void Ctor_WithMinEqualsMaxValue_Throws()
        {
            // Arrange
            var sutAction = new Action(() => new PrimitiveRangeValidationRule<int>(ERROR_MESSAGE, 10, 10));

            // Act / Assert
            sutAction.Should().ThrowExactly<ArgumentException>()
                .Which.ParamName.Should().Be("minValue");
        }

        [Test]
        public void Ctor_WithMinGreaterMaxValue_Throws()
        {
            // Arrange
            var sutAction = new Action(() => new PrimitiveRangeValidationRule<int>(ERROR_MESSAGE, 10, 9));

            // Act / Assert
            sutAction.Should().ThrowExactly<ArgumentException>()
                .Which.ParamName.Should().Be("minValue");
        }

        [Test]
        public void Validate_WithErrorMessage_HasErrorMessage()
        {
            // Arrange
            var sut = new PrimitiveRangeValidationRule<int>(ERROR_MESSAGE, 0, 100);

            // Act
            var result = sut.Validate(-1000);

            // Assert
            sut.ErrorMessage.Should().Be(ERROR_MESSAGE);
        }

        [Test]
        public void Validate_WithMaxError_AndNoMaxErrorMessage_HasMinErrorMessage()
        {
            // Arrange
            var minErrorMessage = "Min";
            var sut = new PrimitiveRangeValidationRule<int>(minErrorMessage, null, 0, 100);

            // Act
            var result = sut.Validate(1000);

            // Assert
            sut.ErrorMessage.Should().Be(minErrorMessage);
        }

        [Test]
        public void Validate_WithMaxError_HasMaxErrorMessage()
        {
            // Arrange
            var minErrorMessage = "Min";
            var maxErrorMessage = "Max";
            var sut = new PrimitiveRangeValidationRule<int>(minErrorMessage, maxErrorMessage, 0, 100);

            // Act
            var result = sut.Validate(1000);

            // Assert
            sut.ErrorMessage.Should().Be(maxErrorMessage);
        }

        [Test]
        public void Validate_WithMinError_AndNoMinErrorMessage_HasMaxErrorMessage()
        {
            // Arrange
            var maxErrorMessage = "Max";
            var sut = new PrimitiveRangeValidationRule<int>(null, maxErrorMessage, 0, 100);

            // Act
            var result = sut.Validate(-1000);

            // Assert
            sut.ErrorMessage.Should().Be(maxErrorMessage);
        }

        [Test]
        public void Validate_WithMinError_HasMinErrorMessage()
        {
            // Arrange
            var minErrorMessage = "Min";
            var maxErrorMessage = "Max";
            var sut = new PrimitiveRangeValidationRule<int>(minErrorMessage, maxErrorMessage, 0, 100);

            // Act
            var result = sut.Validate(-1000);

            // Assert
            sut.ErrorMessage.Should().Be(minErrorMessage);
        }
    }
}