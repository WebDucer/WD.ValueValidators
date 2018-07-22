using System;
using System.Globalization;
using WD.ValueValidators.Base;
using Xamarin.Forms;

namespace WD.Validators.Sample.Converters
{
    public class ValidationColorConverter : IValueConverter
    {
        public Color InvalidColor { get; set; } = Color.Red;

        #region Implementation of IValueConverter

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isValid)
            {
                return isValid ? Color.Default : InvalidColor;
            }

            return Color.Default;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}