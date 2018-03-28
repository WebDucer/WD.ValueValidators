using FluentAssertions;
using NUnit.Framework;
using WD.ValueValidators.Rules;
using static WD.ValueValidators.Tests.Constants;

namespace WD.ValueValidators.Tests.Rules
{
    [TestFixture]
    public class RequiredValidationRuleTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void Validate_AllowWhiteSpace_WithNullEmptyValue(string value)
        {
            // Arrange
            var sut = new RequiredValidationRule(ERROR_MESSAGE, true);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().BeFalse();
        }

        [TestCase(" ")]
        [TestCase("\r\n \t ")]
        [TestCase(ERROR_MESSAGE)]
        public void Validate_AllowWhiteSpace_WithNonNullEmptyValue(string value)
        {
            // Arrange
            var sut = new RequiredValidationRule(ERROR_MESSAGE, true);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().BeTrue();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\r\n \t ")]
        public void Validate_WithNullEmptyValue(string value)
        {
            // Arrange
            var sut = new RequiredValidationRule(ERROR_MESSAGE, false);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().BeFalse();
        }

        [TestCase(ERROR_MESSAGE)]
        public void Validate_WithNonNullEmptyValue(string value)
        {
            // Arrange
            var sut = new RequiredValidationRule(ERROR_MESSAGE, false);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void Constructor_SetErrorMessage()
        {
            // Arrange / Act
            var sut = new RequiredValidationRule(ERROR_MESSAGE);

            // Assert
            sut.ErrorMessage.Should().Be(ERROR_MESSAGE);
        }
    }
}