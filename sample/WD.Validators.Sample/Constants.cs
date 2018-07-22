using System;
using Xamarin.Forms;

namespace WD.Validators.Sample
{
    public static class Constants
    {
        public static class FontSize
        {
            private static double _default = double.MinValue;

            public static readonly double SMALL = Default * 0.8;

            public static double Default
            {
                get
                {
                    if (Math.Abs(_default - double.MinValue) < 0.01)
                    {
                        try
                        {
                            _default = Device.GetNamedSize(NamedSize.Default, typeof(Label));
                        }
                        catch
                        {
                            _default = 12;
                        }
                    }

                    return _default;
                }
            }
        }
    }
}