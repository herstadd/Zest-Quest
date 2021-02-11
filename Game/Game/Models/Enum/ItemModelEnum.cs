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
       

       
    }
}