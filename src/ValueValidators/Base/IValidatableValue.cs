using System;
using System.Collections.Generic;

namespace WD.ValueValidators.Base
{
    /// <summary>
    ///     A validatable object
    /// </summary>
    public interface IValidatable
    {
        /// <summary>
        ///     The first error from the error list
        /// </summary>
        string FirstError { get; }

        /// <summary>
        ///     All errors for this object
        /// </summary>
        IEnumerable<string> Errors { get; }

        /// <summary>
        ///     Object is valid
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        ///     Object is not valid (inverse of <see cref="IsValid" />)
        /// </summary>
        bool IsNotValid { get; }

        /// <summary>
        ///     Manual trigger for validation run
        /// </summary>
        void RaiseValidation();

        /// <summary>
        ///     Event that fires on validation changes
        /// </summary>
        event EventHandler<IsValidEventArgs> IsValidChanged;
    }

    /// <summary>
    /// Non generic interface for validatable value
    /// </summary>
    public interface IValidatableValue : IValidatable
    {
        /// <summary>
        /// Value for test
        /// </summary>
        object Value { get; set; }
    }

    /// <summary>
    ///     Validatable value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidatableValue<T> : IValidatable
    {
        /// <summary>
        ///     Value of the object
        /// </summary>
        T Value { get; set; }
    }
}