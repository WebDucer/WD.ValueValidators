using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using WD.ValueValidators.Rules;
using static WD.ValueValidators.Tests.Constants;

namespace WD.ValueValidators.Tests.Rules
{
    [TestFixture]
    public class ContainsValidationRuleTests
    {
        [Test]
        public void Constructor_WithNullCollection_Throws()
        {
            // Arrange
            var sutAction = new Action(() => new ContainsValidationRule<string>(ERROR_MESSAGE, null));

            // Act / Assert
            sutAction.Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("checkCollection");
        }

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        public void Validate_IncludedValue(string value)
        {
            // Arrange
            var collection = new[] {"1", "2", "3"};
            var sut = new ContainsValidationRule<string>(ERROR_MESSAGE, collection);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void Validate_NotIncludedValue()
        {
            // Arrange
            const string value = "0";
            var collection = new[] {"1", "2", "3"};
            var sut = new ContainsValidationRule<string>(ERROR_MESSAGE, collection);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().BeFalse();
        }

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        public void Validate_IncludedValue_Inverse(string value)
        {
            // Arrange
            var collection = new[] {"1", "2", "3"};
            var sut = new ContainsValidationRule<string>(ERROR_MESSAGE, collection, true);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void Validate_NotIncludedValue_Inverse()
        {
            // Arrange
            const string value = "4";
            var collection = new[] {"1", "2", "3"};
            var sut = new ContainsValidationRule<string>(ERROR_MESSAGE, collection, true);

            // Act
            var result = sut.Validate(value);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void Constructor_SetErrorMessage()
        {
            // Arrange / Act
            var collection = new[] {"1", "2", "3"};
            var sut = new ContainsValidationRule<string>(ERROR_MESSAGE, collection);

            // Assert
            sut.ErrorMessage.Should().Be(ERROR_MESSAGE);
        }
    }
}
