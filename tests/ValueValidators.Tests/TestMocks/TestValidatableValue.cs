using System;
using WD.ValueValidators.Base;

namespace WD.ValueValidators.Tests.TestMocks
{
    public class TestValidatableValue : ValidatableValue<int>
    {
        public int ValidationCalled
        {
            get;
            private set;
        } = 0;

        protected override void ValidateValue(int value)
        {
            ValidationCalled++;
        }
    }
}
