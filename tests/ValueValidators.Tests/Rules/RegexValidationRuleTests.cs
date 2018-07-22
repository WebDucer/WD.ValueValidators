using System;
using System.Text.RegularExpressions;
using FluentAssertions;
using NUnit.Framework;
using WD.ValueValidators.Rules;

namespace WD.ValueValidators.Tests.Rules
{
    [TestFixture]
    public class RegexValidationRuleTests
    {
        private const string _ERROR_MESSAGE = "Error";

        [Test]
        public void Constructor_WithNullExpression_Throws()
        {
            // Arrange
            var sutAction = new Action(() => new RegexValidationRule(_ERROR_MESSAGE, (Regex) null));

            // Act / Assert
            sutAction.Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("expression");
        }

        [Test]
        public void Constructor_WithNullExpressionPattern_Throws()
        {
            // Arrange
            var sutAction = new Action(() => new RegexValidationRule(_ERROR_MESSAGE, (string) null));

            // Act / Assert
            sutAction.Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("pattern");
        }

        [TestCase(@"\d+", false, false, false)]
        [TestCase(@"\d+", true, false, true)]
        [TestCase(@"\d+", true, true, false)]
        [TestCase(@"\d+", false, true, true)]
        public void Validate_ForNullValue(string pattern, bool nullIsValid, bool invert,
            bool expected)
        {
            // Arrange
            var sut = new RegexValidationRule(_ERROR_MESSAGE, pattern, nullIsValid, invert);

            // Act
            var result = sut.Validate(null);

            // Assert
            result.Should().Be(expected);
        }

        [TestCase(@"\d+", false, false, false)]
        [TestCase(@"\d+", true, false, true)]
        [TestCase(@"\d+", true, true, false)]
        [TestCase(@"\d+", false, true, true)]
        public void Validate_ForEmptyValue(string pattern, bool nullIsValid, bool invert,
            bool expected)
        {
            // Arrange
            var sut = new RegexValidationRule(_ERROR_MESSAGE, pattern, nullIsValid, invert);

            // Act
            var result = sut.Validate(string.Empty);

            // Assert
            result.Should().Be(expected);
        }

        [TestCase(@"\d+", false, false, false)]
        [TestCase(@"\d+", true, false, false)]
        [TestCase(@"\d+", true, true, true)]
        [TestCase(@"\d+", false, true, true)]
        public void Validate_ForInvalidValue(string pattern, bool nullIsValid, bool invert,
            bool expected)
        {
            // Arrange
            var sut = new RegexValidationRule(_ERROR_MESSAGE, pattern, nullIsValid, invert);

            // Act
            var result = sut.Validate("abc");

            // Assert
            result.Should().Be(expected);
        }

        [TestCase(@"\d+", false, false, true)]
        [TestCase(@"\d+", true, false, true)]
        [TestCase(@"\d+", true, true, false)]
        [TestCase(@"\d+", false, true, false)]
        public void Validate_ForValidValue(string pattern, bool nullIsValid, bool invert,
            bool expected)
        {
            // Arrange
            var sut = new RegexValidationRule(_ERROR_MESSAGE, pattern, nullIsValid, invert);

            // Act
            var result = sut.Validate("321");

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public void Constructor_SetErrorMessage()
        {
            // Arrange / Act
            var sut = new RegexValidationRule(_ERROR_MESSAGE, @"\d+");

            // Assert
            sut.ErrorMessage.Should().Be(_ERROR_MESSAGE);
        }
    }
}