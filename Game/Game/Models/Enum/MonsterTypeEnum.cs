﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The Types of Jobs a character can have
    /// Used in Character Crudi, and in Battles.
    /// </summary>
    public enum MonsterTypeEnum
    {
        // Unknown is not used at the moment, but has no skills
        Unknown = 0,

        // Evil Refrigerator's items is Boss type and has special items to drop
        EvilRefrigerator = 10,

        // Evil Toaster's items is Boss type and has special items to drop
        EvilToaster = 12,

        // Evil Blender's items is Boss type and has special items to drop
        EvilBlender = 15,

        // Evil Dishwasher's items is standard type and has No special items to drop
        EvilDishwasher = 18,

        // Evil Stove's items is standard type and has No special items to drop
        EvilStove = 22,

        // Evil Kitchen Sink's items is standard type and has No special items to drop
        EvilKitchenSink = 25,

        // Evil Rice Cooker's items is standard type and has No special items to drop
        EvilRiceCooker = 28,

        // Evil Crock pot's items is standard type and has No special items to drop
        EvilCrockpot = 31,

        // Evil Can Opener's items is standard type and has No special items to drop
        EvilCanOpener = 34,

    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class MonsterJobEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this MonsterTypeEnum value)
        {
            // Default String
            var Message = "Player";

            switch (value)
            {
                case MonsterTypeEnum.EvilRefrigerator:
                    Message = "Evil Refrigerator";
                    break;

                case MonsterTypeEnum.EvilToaster:
                    Message = "Evil Toaster";
                    break;

                case MonsterTypeEnum.EvilBlender:
                    Message = "Evil Blender";
                    break;

                case MonsterTypeEnum.EvilDishwasher:
                    Message = "Evil Dishwasher";
                    break;

                case MonsterTypeEnum.EvilStove:
                    Message = "Evil Stove";
                    break;

                case MonsterTypeEnum.EvilKitchenSink:
                    Message = "Evil Kitchen Sink";
                    break;

                case MonsterTypeEnum.EvilRiceCooker:
                    Message = "Evil Rice Cooker";
                    break;

                case MonsterTypeEnum.EvilCrockpot:
                    Message = "Evil Crock pot";
                    break;

                case MonsterTypeEnum.EvilCanOpener:
                    Message = "Evil Can Opener";
                    break;

                case MonsterTypeEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }

        /// <summary>
        /// Gets the name of the picture that is associated with the Monster type
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetPicture(this MonsterTypeEnum value)
        {
            // Default String
            var MonsterImage = "None";

            switch (value)
            {
                case MonsterTypeEnum.EvilRefrigerator:
                    MonsterImage = "monster2.png";
                    break;

                case MonsterTypeEnum.EvilToaster:
                    MonsterImage = "crock_pot.png";
                    break;

                case MonsterTypeEnum.EvilBlender:
                    MonsterImage = "crock_pot.png";
                    break;

                case MonsterTypeEnum.EvilDishwasher:
                    MonsterImage = "crock_pot.png";
                    break;

                case MonsterTypeEnum.EvilStove:
                    MonsterImage = "crock_pot.png";
                    break;

                case MonsterTypeEnum.EvilKitchenSink:
                    MonsterImage = "crock_pot.png";
                    break;

                case MonsterTypeEnum.EvilRiceCooker:
                    MonsterImage = "crock_pot.png";
                    break;

                case MonsterTypeEnum.EvilCrockpot:
                    MonsterImage = "crock_pot.png";
                    break;

                case MonsterTypeEnum.EvilCanOpener:
                    MonsterImage = "crock_pot.png";
                    break;

                case MonsterTypeEnum.Unknown:
                default:
                    break;
            }

            return MonsterImage;
        }

        /// <summary>
        /// Displays a Special drop for a Enum type monster
        /// </summary>
        /// <param name="value"></param>
        /// <returns>String value of Special drop</returns>
        public static string GetSpecialDrop(this MonsterTypeEnum value)
        {
            // Default String
            var Message = "None";

            switch (value)
            {
                case MonsterTypeEnum.EvilRefrigerator:
                    Message = "Refrigerator";
                    break;

                case MonsterTypeEnum.EvilToaster:
                    Message = "OnionRing";
                    break;

                case MonsterTypeEnum.EvilBlender:
                    Message = "ButcherKnife";
                    break;               

                case MonsterTypeEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }

        /// <summary>
        /// Displays a Description for a Enum type monster
        /// </summary>
        /// <param name="value"></param>
        /// <returns>String value of Discription</returns>
        public static string GetMonsterDescription(this MonsterTypeEnum value)
        {
            // Default String
            var Message = "This is a basic Monster";

            switch (value)
            {
                case MonsterTypeEnum.EvilRefrigerator:
                    Message = "This is a special Monster and holds a Refrigerator";
                    break;

                case MonsterTypeEnum.EvilToaster:
                    Message = "This is a special Monster and holds a OnionRing";
                    break;

                case MonsterTypeEnum.EvilBlender:
                    Message = "This is a special Monster and holds a ButcherKnife";
                    break;

                case MonsterTypeEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }

        /// <summary>
        /// Displays The Class of a Enum type monster
        /// </summary>
        /// <param name="value"></param>
        /// <returns>String value of the Monster Class</returns>
        public static string GetMonsterClass(this MonsterTypeEnum value)
        {
            // Default String
            var Message = "Standard";

            switch (value)
            {
                case MonsterTypeEnum.EvilRefrigerator:
                    Message = "Boss";
                    break;

                case MonsterTypeEnum.EvilToaster:
                    Message = "Boss";
                    break;

                case MonsterTypeEnum.EvilBlender:
                    Message = "Boss";
                    break;

                case MonsterTypeEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for the Attribute Enum Class
    /// </summary>
    public static class MonsterJobEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for Attribute
        /// Removes the attributes that are not changable by Items such as Unknown
        /// </summary>
        public static List<string> GetListItem
        {
            get
            {
                var myList = Enum.GetNames(typeof(MonsterTypeEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum for Attribute
        /// Removes the unknown
        /// </summary>
        public static List<string> GetListMonster
        {
            get
            {
                var myList = Enum.GetNames(typeof(MonsterTypeEnum)).ToList().Where(m => m.ToString().Equals("Unknown") == false).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static MonsterTypeEnum ConvertStringToEnum(string value)
        {
            return (MonsterTypeEnum)Enum.Parse(typeof(MonsterTypeEnum), value);
        }
    }
}