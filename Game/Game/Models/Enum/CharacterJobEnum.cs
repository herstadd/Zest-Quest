using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The Types of Jobs a character can have
    /// Used in Character Crudi, and in Battles.
    /// </summary>
    public enum CharacterJobEnum
    {
        // Not specified
        Unknown = 0,    

        // Fighters hit hard and have fight abilities
        HeadChef = 10,

        // Clerics defend well and have buff abilities
        SousChef = 12,

        SchoolChef = 15,

        SushiChef = 18,

        CatChef = 22,

        HomeCook = 24,

    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class CharacterJobEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this CharacterJobEnum value)
        {
            // Default String
            var Message = "Player";

            switch (value)
            {
                case CharacterJobEnum.HeadChef:
                    Message = "Head Chef";
                    break;

                case CharacterJobEnum.SousChef:
                    Message = "Sous Chef";
                    break;

                case CharacterJobEnum.SchoolChef:
                    Message = "School Chef";
                    break;

                case CharacterJobEnum.SushiChef:
                    Message = "Sushi Chef";
                    break;

                case CharacterJobEnum.CatChef:
                    Message = "Cat Chef";
                    break;

                case CharacterJobEnum.HomeCook:
                    Message = "Home Cook";
                    break;

                case CharacterJobEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for the Attribute Enum Class
    /// </summary>
    public static class CharacterJobEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for Attribute
        /// Removes the attributes that are not changable by Items such as Unknown, MaxHealth
        /// </summary>
        public static List<string> GetListItem
        {
            get
            {
                var myList = Enum.GetNames(typeof(CharacterJobEnum)).ToList();
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
                var myList = Enum.GetNames(typeof(CharacterJobEnum)).ToList().Where(m => m.ToString().Equals("Unknown") == false).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static CharacterJobEnum ConvertStringToEnum(string value)
        {
            return (CharacterJobEnum)Enum.Parse(typeof(CharacterJobEnum), value);
        }
    }
}