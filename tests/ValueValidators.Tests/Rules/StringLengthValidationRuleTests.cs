using System;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using WD.ValueValidators.Rules;

namespace WD.ValueValidators.Tests.Rules
{
    [TestFixture]
    public class StringLengthValidationRuleTests
    {
        private const string _ERROR_MESSAGE = "Error";

        [Test]
        public void Constructor_WithNegativeLength_Throws()
        {
            // Arrange
            var sutAction = new Action(() => new StringLengthValidationRule(_ERROR_MESSAGE, -1));

            // Act / Assert
            sutAction.Should().ThrowExactly<ArgumentException>()
                .Which.ParamName.Should().Be("length");
        }

        [TestCase(10, 1, true)]
        [TestCase(10, 9, true)]
        [TestCase(10, 10, true)]
        [TestCase(10, 11, false)]
        public void Validate_ForMaxLength(int length, int valueLength, bool expected)
        {
            // Arrange
            var value = GetValueOfLength(valueLength);
            var sut = new StringLengthValidationRule(_ERROR_MESSAGE, length);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().Be(expected);
        }

        [TestCase(10, 9, false)]
        [TestCase(10, 10, true)]
        [TestCase(10, 11, true)]
        [TestCase(10, 100, true)]
        public void Validate_ForMinLength(int length, int valueLength, bool expected)
        {
            // Arrange
            var value = GetValueOfLength(valueLength);
            var sut = new StringLengthValidationRule(_ERROR_MESSAGE, length, checkMaxLength: false);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public void Validate_ForNullNotAllowed_Fails()
        {
            // Arrange
            string value = null;
            var sut = new StringLengthValidationRule(_ERROR_MESSAGE, 20);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void Validate_ForNullAllowed_Pass()
        {
            // Arrange
            string value = null;
            var sut = new StringLengthValidationRule(_ERROR_MESSAGE, 20, nullIsValid: true);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void Constructor_SetErrorMessage()
        {
            // Arrange / Act
            var sut = new StringLengthValidationRule(_ERROR_MESSAGE, 20);

            // Assert
            sut.ErrorMessage.Should().Be(_ERROR_MESSAGE);
        }

        private string GetValueOfLength(int length)
        {
            var builder = new StringBuilder();
            while (builder.Length < length)
            {
                builder.Append(Guid.NewGuid().ToString("D"));
            }

            return builder.ToString(0, length);
        }
    }
}