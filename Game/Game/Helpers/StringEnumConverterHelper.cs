using System;
using System.Globalization;
using Xamarin.Forms;

namespace Game.Helpers
{ 
    // This converter is used by the Pickers, to change from the picker value to the string value etc.
    // This allows the convert in the picker to be data bound back and forth the model
    // The picker requires this because the picker must be a string, but the enum is a value...

    // Converts from a String to the enum value.  Head = 5, would return 5 for the string "Head", and for "Head" will return 5
    public class StringEnumConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value to the String
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Enum)
            {
                return (int)value;
            }

            if (value is string)
            {
                var aa = targetType.GetType();
                var myReturn = Enum.Parse((targetType), value.ToString());
                return myReturn;
            }

            return 0;
        }

        /// <summary>
        /// Converts a String to the Value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                var myReturn = Enum.ToObject(targetType, value);
                return myReturn.ToString();
            }

            if (value is string)
            {
                var aa = targetType.GetType();
                var myReturn = Enum.Parse((targetType), value.ToString());
                return myReturn;
            }
            return 0;
        }
    }
}