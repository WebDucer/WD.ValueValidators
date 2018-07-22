using FluentAssertions;
using NUnit.Framework;
using WD.ValueValidators.Rules;

namespace WD.ValueValidators.Tests.Rules
{
    [TestFixture]
    public class PhoneNumberValidationRuleTests
    {
        private const string _ERROR_MESSAGE = "Error";

        [TestCase("+49 1234 5678")]
        [TestCase("0123 1234 5678")]
        [TestCase("5678911")]
        [TestCase("+49 1234-5678-02")]
        [TestCase("+49 (12)34-5678-02")]
        [TestCase("(012)34-5678-02")]
        public void Validate_WithValidValue(string value)
        {
            // Arrange
            var sut = new PhoneNumberValidationRule(_ERROR_MESSAGE);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().BeTrue();
        }

        [TestCase("+49 STOP")]
        [TestCase("123_456_78")]
        //[TestCase("+49 1234--5678-02")]
        //[TestCase("+49  1234-5678-02")]
        public void Validate_WithInvalidValue(string value)
        {
            // Arrange
            var sut = new PhoneNumberValidationRule(_ERROR_MESSAGE);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().BeFalse();
        }
    }
}