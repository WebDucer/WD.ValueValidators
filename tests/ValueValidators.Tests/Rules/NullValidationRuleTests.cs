using FluentAssertions;
using NUnit.Framework;
using WD.ValueValidators.Rules;

namespace WD.ValueValidators.Tests.Rules
{
    [TestFixture]
    public class NullValidationRuleTests
    {
        private const string _ERROR_MESSAGE = "Error";

        [TestCase(null, false, false)]
        [TestCase(null, true, true)]
        [TestCase(new int[0], false, true)]
        [TestCase(new int[0], true, false)]
        public void Validate_ForValue(object value, bool invert, bool expected)
        {
            // Arrange
            var sut = new NullValidationRule<object>(_ERROR_MESSAGE, invert);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public void Constructor_SetErrorMessage()
        {
            // Arrange / Act
            var sut = new NullValidationRule<object>(_ERROR_MESSAGE, false);

            // Assert
            sut.ErrorMessage.Should().Be(_ERROR_MESSAGE);
        }
    }
}