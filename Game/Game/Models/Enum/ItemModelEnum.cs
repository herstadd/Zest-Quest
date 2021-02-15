using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The Types of Items
    /// </summary>
    public enum ItemModelEnum
    {
        // Not specified
        Unknown = 0,

        // Chef Hat
        ChefHat = 10,

        // Bandana
        Bandana = 20,

        // Roasted Turkey Hat
        RoastedTurkeyHat = 30,

        // Butcher Knife Necklace
        ButcherKnifeNecklace = 40,

        // Timer
        Timer = 50,

        // Apron
        Apron = 60,

        // Refrigerator
        Refrigerator = 70,

        // Pan
        Pan = 80,

        // Knife
        Knife = 90,

        // Cutting Board
        CuttingBoard = 100,

        // Ring Pop
        RingPop = 110,

        // Scream Ring
        ScreamRing = 120,

        // Onion Ring
        OnionRing = 130,

        // FlipFlops
        FlipFlop = 140,

        // Crocs
        Crocs = 150,

        //Wookie Boots
        WookieBoots = 160,

        //Santa Shoes
        SantaShoes = 170,       
    }

    /// <summary>
    /// Friendly strings for the Item class
    /// </summary>
    public static class ItemModelEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this ItemModelEnum value)
        {
            // Default String
            var Message = "None";

            switch (value)
            {
                case ItemModelEnum.Apron:
                    Message = "Apron";
                    break;

                case ItemModelEnum.Bandana:
                    Message = "Bandana";
                    break;

                case ItemModelEnum.ChefHat:
                    Message = "Chef Hat";
                    break;

                case ItemModelEnum.RoastedTurkeyHat:
                    Message = "Roasted Turkey Hat";
                    break;

                case ItemModelEnum.ButcherKnifeNecklace:
                    Message = "Butcher Knife Necklace";
                    break;

                case ItemModelEnum.Timer:
                    Message = "Timer";
                    break;

                case ItemModelEnum.Refrigerator:
                    Message = "Refrigerator";
                    break;

                case ItemModelEnum.Pan:
                    Message = "Pan";
                    break;

                case ItemModelEnum.Knife:
                    Message = "Knife";
                    break;

                case ItemModelEnum.CuttingBoard:
                    Message = "Cutting Board";
                    break;

                case ItemModelEnum.RingPop:
                    Message = "Ring Pop";
                    break;

                case ItemModelEnum.ScreamRing:
                    Message = "Scream Ring";
                    break;

                case ItemModelEnum.OnionRing:
                    Message = "Onion Ring";
                    break;

                case ItemModelEnum.FlipFlop:
                    Message = "FlipFlop";
                    break;

                case ItemModelEnum.Crocs:
                    Message = "Crocs";
                    break;

                case ItemModelEnum.WookieBoots:
                    Message = "Wookie Boots";
                    break;

                case ItemModelEnum.SantaShoes:
                    Message = "Santa Shoes";
                    break;

                case ItemModelEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for the Item Model Enum Class
    /// </summary>
    public static class ItemModelEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for Attribute
        /// Removes the attributes that are not changable by Items such as Unknown, MaxHealth
        /// </summary>
        public static List<string> GetListItem
        {
            get
            {
                var myList = Enum.GetNames(typeof(ItemModelEnum)).ToList().Where(m => m.ToString().Equals("Unknown") == false).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ItemModelEnum ConvertStringToEnum(string value)
        {
            return (ItemModelEnum)Enum.Parse(typeof(ItemModelEnum), value);
        }
    }
}