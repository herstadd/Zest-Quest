using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The Types of Difficultys
    /// Used by Item to specify what it modifies.
    /// </summary>
    public enum DifficultyEnum
    {
        // Not specified
        Unknown = 0,    

        // Easier than mostThe speed of the character, impacts movement, and initiative
        Easy = 10,

        // Average
        Average = 12,

        // Hard
        Hard = 14,

        // Harder than Hard
        Difficult = 16,

        // The highest value
        Impossible= 18,
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class DifficultyEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this DifficultyEnum value)
        {
            // Default String
            var Message = "Unknown";

            switch (value)
            {
                case DifficultyEnum.Easy:
                    Message = "Easy";
                    break;

                case DifficultyEnum.Average:
                    Message = "Average";
                    break;

                case DifficultyEnum.Hard:
                    Message = "Hard";
                    break;

                case DifficultyEnum.Difficult:
                    Message = "Harder than Hard";
                    break;

                case DifficultyEnum.Impossible:
                    Message = "Impossible";
                    break;

                case DifficultyEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }

        /// <summary>
        /// Return a modifier as an Int rounded up
        /// 
        /// From the Enun value
        /// 
        /// And the passed in value
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToModifier(this DifficultyEnum EnumValue, int value)
        {
            // Default String
            var modifier = 1.0;

            switch (EnumValue)
            {
                case DifficultyEnum.Easy:
                    modifier = .25;
                    break;

                case DifficultyEnum.Average:
                    modifier = .5;
                    break;

                case DifficultyEnum.Hard:
                    modifier = 1;
                    break;

                case DifficultyEnum.Difficult:
                    modifier = 1.5;
                    break;

                case DifficultyEnum.Impossible:
                    modifier = 2;
                    break;

                case DifficultyEnum.Unknown:
                default:
                    break;
            }

            var MaxHealthAdjusted = Convert.ToInt32(Math.Ceiling(value * modifier));

            return MaxHealthAdjusted;
        }
    }

    /// <summary>
    /// Helper for the Difficulty Enum Class
    /// </summary>
    public static class DifficultyEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for Difficulty
        /// Removes the Difficultys that are not changable by Items such as Unknown, MaxHealth
        /// </summary>
        public static List<string> GetListAll
        {
            get
            {
                var myList = Enum.GetNames(typeof(DifficultyEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum for Difficulty
        /// Removes the unknown
        /// </summary>
        public static List<string> GetListMonster
        {
            get
            {
                var myList = Enum.GetNames(typeof(DifficultyEnum)).ToList().Where(m => m.ToString().Equals("Unknown") == false).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DifficultyEnum ConvertStringToEnum(string value)
        {
            return (DifficultyEnum)Enum.Parse(typeof(DifficultyEnum), value);
        }
    }
}