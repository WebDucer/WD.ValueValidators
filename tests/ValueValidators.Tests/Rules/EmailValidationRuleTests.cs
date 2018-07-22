using FluentAssertions;
using NUnit.Framework;
using WD.ValueValidators.Rules;

namespace WD.ValueValidators.Tests.Rules
{
    [TestFixture]
    public class EmailValidationRuleTests
    {
        private const string _ERROR_MESSAGE = "Error";

        [TestCase("test@example.com")]
        [TestCase("t_e-st@e-x_ample.com")]
        [TestCase("a@b.c")]
        [TestCase("a@b.c.d.e")]
        public void Validate_WithValidValue(string value)
        {
            // Arrange
            var sut = new EmailValidationRule(_ERROR_MESSAGE);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().BeTrue();
        }

        [TestCase("test@example.com-de")]
        [TestCase("test")]
        [TestCase("test@com")]
        [TestCase("test_example.com")]
        public void Validate_WithInvalidValue(string value)
        {
            // Arrange
            var sut = new EmailValidationRule(_ERROR_MESSAGE);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().BeFalse();
        }
    }
}