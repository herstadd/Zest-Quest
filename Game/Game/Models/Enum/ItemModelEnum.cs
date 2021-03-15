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
                ItemModelEnum.ChefHat => "Chef Hat",
                ItemModelEnum.RoastedTurkeyHat => "Roasted Turkey Hat",
                ItemModelEnum.ButcherKnifeNecklace => "Butcher Knife Necklace",
                ItemModelEnum.Timer => "Timer",
                ItemModelEnum.Refrigerator => "Refrigerator",
                ItemModelEnum.Pan => "Pan",
                ItemModelEnum.Knife => "Knife",
                ItemModelEnum.CuttingBoard => "Cutting Board",
                ItemModelEnum.RingPop => "Ring Pop",
                ItemModelEnum.ScreamRing => "Scream Ring",
                ItemModelEnum.OnionRing => "Onion Ring",
                ItemModelEnum.FlipFlop => "Flip Flop",
                ItemModelEnum.Crocs => "Crocs",
                ItemModelEnum.WookieBoots => "Wookie Boots",
                ItemModelEnum.SantaShoes => "Santa Shoes",
                ItemModelEnum.FriedChickenNecklace => "Fried Chicken Necklace",
                ItemModelEnum.Gingerbread => "Gingerbread",
                ItemModelEnum.MeatGuitar => "Meat Guitar",
                ItemModelEnum.Pot => "Pot",
                ItemModelEnum.Puppet => "Puppet",
                ItemModelEnum.VikingHat => "Viking Hat",
                ItemModelEnum.WeddingRing => "Wedding Ring",
                ItemModelEnum.WitchNail => "Witch Nail",
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
        ///  Gets the list of Item names a character can use
        ///  Removes Unknown, None
        /// </summary>
        public static List<string> GetListItems
        {
            get
            {
                var myList = new List<string>();
                foreach (ItemModelEnum item in Enum.GetValues(typeof(ItemModelEnum)))
                {
                    if (item != ItemModelEnum.Unknown &&
                        item != ItemModelEnum.None)
                        myList.Add(item.ToMessage());
                }

                return myList;
            }
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
        public static ItemModelEnum ConvertMessageToEnum(string value)
        {
            value = value.Replace(" ", "");

            // Get the Message, Determine Which enum has that message, and return that enum.
            foreach (ItemModelEnum item in Enum.GetValues(typeof(ItemModelEnum)))
            {
                if (item.ToString().Equals(value))
                {
                    return item;
                }
            }
            return ItemModelEnum.Unknown;
        }
    }
}