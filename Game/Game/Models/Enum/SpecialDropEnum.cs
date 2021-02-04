using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The unique Drop Items can be
    /// dropped by a Monster in Battles.
    /// </summary>
    public enum SpecialDropEnum
    {
        // Unknown is not used at the moment, but has no skills
        Unknown = 0,

        // Attribute:Attack | Value:+6 | Location:Hand |Range:5
        Refrigerator = 10,

        // Attribute:Health | Value:+4 | Location:Finger |Range:0
        OnionRing = 12,

        // Attribute:Attack | Value:+3 | Location:Necklace |Range:2
        ButcherKnife = 15,

        // Attribute:Defense | Value:+3 | Location:Necklace |Range:0
        FriedChicken = 18,

        // Attribute:Speed | Value:+5 | Location:Necklace |Range:0
        ScreamRing = 22,
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class SpecialDropEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this SpecialDropEnum value)
        {
            // Default String
            var Message = "Player";

            switch (value)
            {
                case SpecialDropEnum.ButcherKnife:
                    Message = "Butcher Knife";
                    break;

                case SpecialDropEnum.FriedChicken:
                    Message = "Fried Chicken";
                    break;

                case SpecialDropEnum.OnionRing:
                    Message = "Onion Ring";
                    break;

                case SpecialDropEnum.Refrigerator:
                    Message = "Refrigerator";
                    break;

                case SpecialDropEnum.ScreamRing:
                    Message = "Scream Ring";
                    break;

                case SpecialDropEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for the Attribute Enum Class
    /// </summary>
    public static class SpecialDropEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for Attribute
        /// Removes the attributes that are not changable by Items such as Unknown
        /// </summary>
        public static List<string> GetListItem
        {
            get
            {
                var myList = Enum.GetNames(typeof(SpecialDropEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum for Attribute
        /// Removes the unknown
        /// </summary>
        public static List<string> GetListSpecialDrop
        {
            get
            {
                var myList = Enum.GetNames(typeof(SpecialDropEnum)).ToList().Where(m => m.ToString().Equals("Unknown") == false).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SpecialDropEnum ConvertStringToEnum(string value)
        {
            return (SpecialDropEnum)Enum.Parse(typeof(SpecialDropEnum), value);
        }
    }
}