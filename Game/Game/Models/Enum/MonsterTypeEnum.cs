using System;
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
    public static class MonsterTypeEnumExtensions
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
    }

    /// <summary>
    /// Helper for the Attribute Enum Class
    /// </summary>
    public static class MonsterTypeEnumHelper
    {
        /// <summary>
        ///  Gets the list of monsters can use
        ///  Removes Unknown, None
        /// </summary>
        public static List<string> GetListItems
        {
            get
            {
                var myList = new List<string>();
                foreach (MonsterTypeEnum item in Enum.GetValues(typeof(MonsterTypeEnum)))
                {
                    if (item != MonsterTypeEnum.Unknown)
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
        public static MonsterTypeEnum ConvertStringToEnum(string value)
        {
            value = value.Replace(" ", "");
            return (MonsterTypeEnum)Enum.Parse(typeof(MonsterTypeEnum), value);
        }

        /// <summary>
        /// Given the Message for an enum
        /// Look it up and return the enum
        /// 
        /// Chef Hat => ChefHat
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static MonsterTypeEnum ConvertMessageToEnum(string value)
        {
            value = value.Replace(" ", "");

            // Get the Message, Determine Which enum has that message, and return that enum.
            foreach (MonsterTypeEnum item in Enum.GetValues(typeof(MonsterTypeEnum)))
            {
                if (item.ToString().Equals(value))
                {
                    return item;
                }
            }
            return MonsterTypeEnum.Unknown;
        }
    }
}