using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The Types of Attributes
    /// Used by Item to specify what it modifies.
    /// </summary>
    public enum AttributeEnum
    {
        // Not specified
        Unknown = 0,    

        // The speed of the character, impacts movement, and initiative
        Speed = 10,

        // The defense score, to be used for defending against attacks
        Defense = 12,

        // The Attack score to be used when attacking
        Attack = 14,

        // Current Health which is always at or below MaxHealth
        CurrentHealth = 16,

        // The highest value health can go
        MaxHealth = 18,
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class AttributeEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this AttributeEnum value)
        {
            // Default String
            var Message = "Unknown";

            switch (value)
            {
                case AttributeEnum.Attack:
                    Message = "Attack";
                    break;

                case AttributeEnum.CurrentHealth:
                    Message = "Current Health";
                    break;

                case AttributeEnum.Defense:
                    Message = "Defense";
                    break;

                case AttributeEnum.MaxHealth:
                    Message = "Max Health";
                    break;

                case AttributeEnum.Speed:
                    Message = "Speed";
                    break;

                case AttributeEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for the Attribute Enum Class
    /// </summary>
    public static class AttributeEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for Attribute
        /// Removes the attributes that are not changable by Items such as Unknown, MaxHealth
        /// </summary>
        public static List<string> GetListItem
        {
            get
            {
                var myList = Enum.GetNames(typeof(AttributeEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum for Attribute
        /// Removes the unknown
        /// </summary>
        public static List<string> GetListCharacter
        {
            get
            {
                var myList = Enum.GetNames(typeof(AttributeEnum)).ToList().Where(m => m.ToString().Equals("Unknown") == false).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static AttributeEnum ConvertStringToEnum(string value)
        {
            return (AttributeEnum)Enum.Parse(typeof(AttributeEnum), value);
        }
    }
}