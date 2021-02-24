using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// Enum for Monster Class
    /// </summary>
    public enum MonsterClassEnum
    {
        // Boss Monster
        Boss = 1,

        // Standard Monster
        Standard = 3,
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class MonsterClassEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this MonsterClassEnum value)
        {
            // Default String
            var Message = "Standard";

            switch (value)
            {
                case MonsterClassEnum.Boss:
                    Message = "Boss";
                    break;

                case MonsterClassEnum.Standard:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for the Attribute Enum Class
    /// </summary>
    public static class MonsterClassEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for Attribute
        /// Removes the unknown
        /// </summary>
        public static List<string> GetListMonsterClass
        {
            get
            {
                var myList = Enum.GetNames(typeof(MonsterClassEnum)).ToList().Where(m => m.ToString().Equals("Unknown") == false).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static MonsterClassEnum ConvertStringToEnum(string value)
        {
            return (MonsterClassEnum)Enum.Parse(typeof(MonsterClassEnum), value);
        }
    }
}