using FluentAssertions;
using NUnit.Framework;
using WD.ValueValidators.Rules;
using WD.ValueValidators.Tests.TestMocks;

namespace WD.ValueValidators.Tests.Rules
{
    [TestFixture]
    public class RevalidateOtherValueValidationRuleTests
    {
        [Test]
        public void Validation_TriggerValidation_OnOtherValue()
        {
            // Arrange
            var triggeredValue = new TestValidatableValue();
            var sut = new RevalidateOtherValueValidationRule<int>(triggeredValue);

            // Act
            triggeredValue.ValidationCalled.Should().Be(0);
            sut.Validate(100);

            // Assert
            triggeredValue.ValidationCalled.Should().Be(1);
        }
    }
}
