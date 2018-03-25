using System;

namespace WD.ValueValidators.Base
{
    /// <summary>
    ///     Event argument for the is valid event
    /// </summary>
    public class IsValidEventArgs : EventArgs
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="isValid">value of is vlaid change</param>
        public IsValidEventArgs(bool isValid)
        {
            IsValid = isValid;
        }

        /// <summary>
        ///     Value of the is valid change
        /// </summary>
        public bool IsValid { get; }
    }
}