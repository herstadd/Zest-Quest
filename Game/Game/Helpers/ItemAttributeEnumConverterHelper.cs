using Game.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Game.Helpers
{ 
    // This converter is used by the Pickers, to change from the picker value to the string value etc.
    // This allows the convert in the picker to be data bound back and forth the model
    // The picker requires this because the picker must be a string, but the enum is a value...

    // Converts from a String to the enum value.  Speed = 10, would return 10 for the string "Speed", and for "Speed" will return 10
    public class ItemAttributeEnumConverter : IValueConverter
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
                //return (int)value;
                return ((AttributeEnum)value).ToMessage();
            }

            if (value is string)
            {
                // Convert String Enum and then Enum to Message
                var myEnum = AttributeEnumHelper.ConvertMessageToEnum((string)value);
                var myReturn = myEnum.ToMessage();

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
                // Convert the int to the Enum
                var myReturn = Enum.ToObject(targetType, value);
                return ((AttributeEnum)myReturn).ToMessage();
            }

            if (value is string)
            {
                // Convert the Message String to the Enum
                var myReturn = AttributeEnumHelper.ConvertMessageToEnum((string)value);
                    
                return myReturn;
            }
            return 0;
        }
    }
}