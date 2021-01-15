using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The Types of s a Ability can have
    /// Used in Ability Crudi, and in Battles.
    /// </summary>
    public enum AbilityEnum
    {
        // Not specified
        Unknown = 0,

        // Not specified
        None = 1,

        // General Abilities 10 Range
        // Heal Self
        Bandage = 10,


        // Fighter Abilities > 20 Range
        // Buff Speed
        Nimble = 21,

        // Buff Defense
        Toughness = 22,

        // Buff Attack
        Focus = 23,


        // Cleric Abilities > 50 Range
        // Buff Speed
        Quick = 51,

        // Buff Defense
        Barrier = 52,

        // Buff Attack
        Curse = 53,

        // Heal Self
        Heal = 54,
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class AbilityEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this AbilityEnum value)
        {
            // Default String
            var Message = "None";

            switch (value)
            {
                case AbilityEnum.Bandage:
                    Message = "Apply Bandages";
                    break;

                case AbilityEnum.Nimble:
                    Message = "React Quickly";
                    break;

                case AbilityEnum.Toughness:
                    Message = "Toughen Up";
                    break;

                case AbilityEnum.Focus:
                    Message = "Mental Focus";
                    break;

                case AbilityEnum.Quick:
                    Message = "Anticipate";
                    break;

                case AbilityEnum.Barrier:
                    Message = "Barrier Defense";
                    break;

                case AbilityEnum.Curse:
                    Message = "Shout Curse";
                    break;

                case AbilityEnum.Heal:
                    Message = "Heal Self";
                    break;

                case AbilityEnum.None:
                case AbilityEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for the Ability Enum Class
    /// </summary>
    public static class AbilityEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for Ability
        /// Removes the Abilitys that are not changable by Items such as Unknown, MaxHealth
        /// </summary>
        public static List<string> GetFullList
        {
            get
            {
                var myList = Enum.GetNames(typeof(AbilityEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum for Fighter
        /// </summary>
        public static List<string> GetListFighter
        {
            get
            {
                List<string> AbilityList = new List<string>{
                AbilityEnum.Nimble.ToString(),
                AbilityEnum.Toughness.ToString(),
                AbilityEnum.Focus.ToString()
                };

                AbilityList.AddRange(GetListOthers);
                return AbilityList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum for Cleric
        /// </summary>
        public static List<string> GetListCleric
        {
            get
            {

                List<string> AbilityList = new List<string>{
                AbilityEnum.Quick.ToString(),
                AbilityEnum.Barrier.ToString(),
                AbilityEnum.Curse.ToString(),
                AbilityEnum.Heal.ToString()
                };

                AbilityList.AddRange(GetListOthers);
                return AbilityList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum of not Cleric or Fighter
        /// </summary>
        public static List<string> GetListOthers
        {
            get
            {

                List<string> AbilityList = new List<string>{
                AbilityEnum.Bandage.ToString(),
                };

                return AbilityList;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static AbilityEnum ConvertStringToEnum(string value)
        {
            return (AbilityEnum)Enum.Parse(typeof(AbilityEnum), value);
        }
    }
}