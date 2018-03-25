using System;

namespace WD.ValueValidators.Tests.TestMocks
{
    public class RangeTestClass : IComparable<RangeTestClass>, IComparable
    {
        private readonly int _value;

        public RangeTestClass(int value)
        {
            _value = value;
        }

        public int CompareTo(object obj)
        {
            if (obj is RangeTestClass other)
            {
                return CompareTo(other);
            }

            throw new InvalidOperationException($"Only comparisson with type '{nameof(RangeTestClass)}' is possible");
        }

        public int CompareTo(RangeTestClass other)
        {
            return _value.CompareTo(other._value);
        }
    }
}