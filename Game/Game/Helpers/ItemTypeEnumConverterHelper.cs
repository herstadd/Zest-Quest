﻿using Game.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Game.Helpers
{
    // This converter is used by the Pickers, to change from the picker value to the string value etc.
    // This allows the convert in the picker to be data bound back and forth the model
    // The picker requires this because the picker must be a string, but the enum is a value...

    // Converts from a String to the enum value.  Bandana = 20, would return 20 for the string "Bandana", and for "Bandana" will return 20
    public class ItemTypeEnumConverter : IValueConverter
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
                return ((ItemModelEnum)value).ToMessage();
            }

            if (value is string)
            {
                // Convert String Enum and then Enum to Message
                var myEnum = ItemModelEnumHelper.ConvertMessageToEnum((string)value);
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
                return ((ItemModelEnum)myReturn).ToMessage();
            }

            if (value is string)
            {
                // Convert the Message String to the Enum
                var myReturn = ItemModelEnumHelper.ConvertMessageToEnum((string)value);
                    
                return myReturn;
            }
            return 0;
        }
    }
}