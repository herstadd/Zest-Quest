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

        // No special drop
        None = 5,

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

        //Fried Chicken Necklace
        FriedChickenNecklace = 180,

        //Gingerbread
        Gingerbread = 190,

        //Meat Guitar
        MeatGuitar = 200,

        //Pot
        Pot = 210,

        //Puppet
        Puppet = 220,

        //Viking Hat
        VikingHat = 230,

        //Wedding Ring
        WeddingRing = 240,

        //Witch Nail
        WitchNail = 250,
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
            string Message = value switch
            {
                ItemModelEnum.None => "None",
                ItemModelEnum.Apron => "Apron",
                ItemModelEnum.Bandana => "Bandana",
                ItemModelEnum.ChefHat => "ChefHat",
                ItemModelEnum.RoastedTurkeyHat => "RoastedTurkeyHat",
                ItemModelEnum.ButcherKnifeNecklace => "ButcherKnifeNecklace",
                ItemModelEnum.Timer => "Timer",
                ItemModelEnum.Refrigerator => "Refrigerator",
                ItemModelEnum.Pan => "Pan",
                ItemModelEnum.Knife => "Knife",
                ItemModelEnum.CuttingBoard => "CuttingBoard",
                ItemModelEnum.RingPop => "RingPop",
                ItemModelEnum.ScreamRing => "ScreamRing",
                ItemModelEnum.OnionRing => "OnionRing",
                ItemModelEnum.FlipFlop => "FlipFlop",
                ItemModelEnum.Crocs => "Crocs",
                ItemModelEnum.WookieBoots => "WookieBoots",
                ItemModelEnum.SantaShoes => "SantaShoes",
                ItemModelEnum.FriedChickenNecklace => "FriedChickenNecklace",
                ItemModelEnum.Gingerbread => "Gingerbread",
                ItemModelEnum.MeatGuitar => "MeatGuitar",
                ItemModelEnum.Pot => "Pot",
                ItemModelEnum.Puppet => "Puppet",
                ItemModelEnum.VikingHat => "VikingHat",
                ItemModelEnum.WeddingRing => "WeddingRing",
                ItemModelEnum.WitchNail => "WitchNail",
                ItemModelEnum.Unknown => "Unknown",
            };
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
                myList.Remove("None");
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