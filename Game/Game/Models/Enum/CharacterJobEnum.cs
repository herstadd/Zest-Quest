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
        // Unknown is not used at the moment, but has no skills
        Unknown = 0,

        Fighter = 10,

        // Clerics defend well and have buff abilities
        Cleric = 12,

        // Head Chef's items will have double stat modifiers for extra impact
        HeadChef = 13,

        // Sous Chef's attack attribute will be 3 times stronger than usual for the first attack of every round
        SousChef = 14,

        // School Chef will provide a 20% attack buff to the rest of the team if the school chef dies in battle
        SchoolChef = 15,

        // Sushi chef has the ability to attack from anywhere on the map with any item
        SushiChef = 18,

        // Cat Chef has 9 lives (so if character dies, it comes back to life 8 more times) but cannot hold more than
        //   one item at a time
        CatChef = 22,

        // After winning a battle, their current health will be recovered by 10% of original max health up to max health
        HomeCook = 24,

        //Pet to help chef if needed
        Pet = 26,

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
        ///  Gets the list of locations a character can use
        ///  Removes Finger for example, and allows for left and right finger
        /// </summary>
        public static List<string> GetListItems
        {
            get
            {
                var myList = new List<string>();
                foreach (CharacterJobEnum item in Enum.GetValues(typeof(CharacterJobEnum)))
                {
                    if (item != CharacterJobEnum.Unknown &&
                        item != CharacterJobEnum.Fighter &&
                        item != CharacterJobEnum.Cleric &&
                        item != CharacterJobEnum.Pet
                    )
                        myList.Add(item.ToMessage());
                }

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
            value = value.Replace(" ", "");
            return (CharacterJobEnum)Enum.Parse(typeof(CharacterJobEnum), value);
        }

        /// <summary>
        /// Given the Message for an enum
        /// Look it up and return the enum
        /// 
        /// Right Finger => RightFinger
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static CharacterJobEnum ConvertMessageToEnum(string value)
        {
            value = value.Replace(" ", "");

            // Get the Message, Determine Which enum has that message, and return that enum.
            foreach (CharacterJobEnum item in Enum.GetValues(typeof(CharacterJobEnum)))
            {
                if (item.ToString().Equals(value))
                {
                    return item;
                }
            }
            return CharacterJobEnum.Unknown;
        }
    }
}