using System.Collections.Generic;
using Game.Helpers;
using Game.Models;
using Game.ViewModels;

namespace Game.GameRules
{
    public static class DefaultData
    {
        /// <summary>
        /// Load the Default data
        /// </summary>
        /// <returns></returns>
        public static List<ItemModel> LoadData(ItemModel temp)
        {
            var datalist = new List<ItemModel>()
            {
                new ItemModel {
                    Name = "ChefHat",
                    Type = ItemModelEnum.ChefHat,
                    Description = "I1",
                    ImageURI = "mushroom.png",
                    Range = 3,
                    Damage = 9,
                    Value = 4,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "Bandana",
                    Type = ItemModelEnum.Bandana,
                    Description = "I2",
                    ImageURI = "mushroom.png",
                    Range = 0,
                    Damage = 5,
                    Value = 3,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Speed
                },
                new ItemModel {
                    Name = "RoastedTurkeyHat",
                    Type = ItemModelEnum.RoastedTurkeyHat,
                    Description = "I3",
                    ImageURI = "mushroom.png",
                    Range = 0,
                    Damage = 1,
                    Value = 4,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.MaxHealth
                },
                new ItemModel {
                    Name = "ButcherKnifeNecklace",
                    Type = ItemModelEnum.ButcherKnifeNecklace,
                    Description = "I4",
                    ImageURI = "mushroom.png",
                    Range = 2,
                    Damage = 5,
                    Value = 3,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "Timer",
                    Type = ItemModelEnum.Timer,
                    Description = "I5",
                    ImageURI = "mushroom.png",
                    Range = 0,
                    Damage = 0,
                    Value = 4,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.MaxHealth
                },
                new ItemModel {
                    Name = "Apron",
                    Type = ItemModelEnum.Apron,
                    Description = "I6",
                    ImageURI = "mushroom.png",
                    Range = 0,
                    Damage = 0,
                    Value = 3,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Defense
                },
                new ItemModel {
                    Name = "Refrigerator",
                    Type = ItemModelEnum.Refrigerator,
                    Description = "I6",
                    ImageURI = "mushroom.png",
                    Range = 5,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "Pan",
                    Type = ItemModelEnum.Pan,
                    Description = "I6",
                    ImageURI = "mushroom.png",
                    Range = 0,
                    Damage = 6,
                    Value = 4,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Defense
                },
                new ItemModel {
                    Name = "Knife",
                    Type = ItemModelEnum.Knife,
                    Description = "I6",
                    ImageURI = "mushroom.png",
                    Range = 2,
                    Damage = 4,
                    Value = 4,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Speed
                },
                new ItemModel {
                    Name = "CuttingBoard",
                    Type = ItemModelEnum.CuttingBoard,
                    Description = "I6",
                    ImageURI = "mushroom.png",
                    Range = 2,
                    Damage = 7,
                    Value = 5,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "RingPop",
                    Type = ItemModelEnum.RingPop,
                    Description = "I6",
                    ImageURI = "mushroom.png",
                    Range = 0,
                    Damage = 0,
                    Value = 2,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.MaxHealth
                },
                new ItemModel {
                    Name = "ScreamRing",
                    Type = ItemModelEnum.ScreamRing,
                    Description = "I6",
                    ImageURI = "mushroom.png",
                    Range = 0,
                    Damage = 0,
                    Value = 5,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Speed
                },
                new ItemModel {
                    Name = "OnionRing",
                    Type = ItemModelEnum.OnionRing,
                    Description = "I6",
                    ImageURI = "mushroom.png",
                    Range = 0,
                    Damage = 0,
                    Value = 4,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.MaxHealth
                },
                new ItemModel {
                    Name = "FlipFlop",
                    Type = ItemModelEnum.FlipFlop,
                    Description = "I6",
                    ImageURI = "mushroom.png",
                    Range = 4,
                    Damage = 0,
                    Value = 5,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "Crocs",
                    Type = ItemModelEnum.Crocs,
                    Description = "I6",
                    ImageURI = "mushroom.png",
                    Range = 0,
                    Damage = 0,
                    Value = 2,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Defense
                },
                new ItemModel {
                    Name = "WookieBoots",
                    Type = ItemModelEnum.WookieBoots,
                    Description = "I6",
                    ImageURI = "mushroom.png",
                    Range = 0,
                    Damage = 0,
                    Value = 3,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Speed
                },
                new ItemModel {
                    Name = "SantaShoes",
                    Type = ItemModelEnum.SantaShoes,
                    Description = "I6",
                    ImageURI = "mushroom.png",
                    Range = 0,
                    Damage = 0,
                    Value = 5,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.MaxHealth
                },
            };

            return datalist;
        }

    /// <summary>
    /// Load Example Scores
    /// </summary>
    /// <param name="temp"></param>
    /// <returns></returns>
    public static List<ScoreModel> LoadData(ScoreModel temp)
    {
        var datalist = new List<ScoreModel>()
            {
                new ScoreModel {
                    Name = "First Time Playing",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "Trying Again",
                    Description = "Test Data",
                }
            };

        return datalist;
    }

    /// <summary>
    /// Load Characters
    /// </summary>
    /// <param name="temp"></param>
    /// <returns></returns>
    public static List<CharacterModel> LoadData(CharacterModel temp)
    {
        var HeadString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Head);
        var NecklassString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Necklass);
        var PrimaryHandString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.PrimaryHand);
        var OffHandString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.OffHand);
        var FeetString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Feet);
        var RightFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Finger);
        var LeftFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Finger);

            var datalist = new List<CharacterModel>()
            {
                new CharacterModel {
                    Name = "Head Chef",
                    Description = "Each item grants this character double the normal stat modifier",
                    Level = 10,
                    Job = CharacterJobEnum.HeadChef,
                    MaxHealth = DiceHelper.RollDice(10, 10),
                    ImageURI = "headchef.png",
                    //Head = HeadString,
                    //Head = ItemModelEnum.ChefHat
                    Head = "mushroom.png",
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Sous Chef ",
                    Description = "This character's attack attribute will be 3 times stronger than usual for the first attack in every round",
                    Level = 1,
                    Job = CharacterJobEnum.SousChef,
                    MaxHealth = DiceHelper.RollDice(1, 10),
                    ImageURI = "souschef.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "School Chef ",
                    Description = "Provide a 20% attack buff to the rest of team if the school chef dies in a battle",
                    Level = 5,
                    Job = CharacterJobEnum.SchoolChef,
                    MaxHealth = DiceHelper.RollDice(5, 10),
                    ImageURI = "schoolchef.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Sushi Chef ",
                    Description = "Has the ability to attack from anywhere on the map with any item ",
                    Level = 1,
                    Job = CharacterJobEnum.SushiChef,
                    MaxHealth = DiceHelper.RollDice(1, 10),
                    ImageURI = "sushichef.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Cat Chef ",
                    Description = "Has nine lives (so if character dies, comes back to life 8 more times,) but cannot hold more than one item at a time",
                    Level = 1,
                    Job = CharacterJobEnum.CatChef,
                    MaxHealth = DiceHelper.RollDice(1, 10),
                    ImageURI = "catchef.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Home Cook",
                    Description = "After winning a battle their current health will be recovered by 10% of original max health up to max health",
                    Level = 10,
                    Job = CharacterJobEnum.HomeCook,
                    MaxHealth = DiceHelper.RollDice(10, 10),
                    ImageURI = "homechef.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },
            };

        return datalist;
    }

    /// <summary>
    /// Load Monsters
    /// </summary>
    /// <param name="temp"></param>
    /// <returns></returns>
    public static List<MonsterModel> LoadData(MonsterModel temp)
    {
            var datalist = new List<MonsterModel>()
            {
                new MonsterModel {
                    Name = "Evil Refrigerator",
                    MonsterType = MonsterTypeEnum.EvilRefrigerator,
                    Description = "This is a special Monster and holds a Refrigerator",
                    ImageURI = "monster2.png",
                    SpecialDrop = SpecialDropEnum.Refrigerator,
                    MonsterClass = "Boss"
                },

                new MonsterModel {
                    Name = "Evil Toaster",
                    MonsterType = MonsterTypeEnum.EvilToaster,
                    Description = "This is a special Monster and holds a OnionRing",
                    ImageURI = "crock_pot.png",
                    SpecialDrop = SpecialDropEnum.OnionRing,
                    MonsterClass = "Boss"
                },

                new MonsterModel {
                    Name = "Evil Blender",
                    MonsterType = MonsterTypeEnum.EvilBlender,
                    Description = "This is a special Monster and holds a ButcherKnife",
                    ImageURI = "crock_pot.png",
                    SpecialDrop = SpecialDropEnum.ButcherKnife,
                    MonsterClass = "Boss"
                },

                new MonsterModel {
                    Name = "Evil Dishwasher",
                    MonsterType = MonsterTypeEnum.EvilDishwasher,
                    Description = "This is a basic Monster",
                    ImageURI = "crock_pot.png",
                    SpecialDrop = SpecialDropEnum.Unknown,
                    MonsterClass = "Standard"
                },

                new MonsterModel {
                    Name = "Evil Stove",
                    MonsterType = MonsterTypeEnum.EvilStove,
                    Description = "This is a basic Monster",
                    ImageURI = "crock_pot.png",
                    SpecialDrop = SpecialDropEnum.Unknown,
                    MonsterClass = "Standard"
                },

                new MonsterModel {
                    Name = "Evil Kitchen Sink",
                    MonsterType = MonsterTypeEnum.EvilKitchenSink,
                    Description = "This is a basic Monster",
                    ImageURI = "crock_pot.png",
                    SpecialDrop = SpecialDropEnum.Unknown,
                    MonsterClass = "Standard"

                },

                new MonsterModel {
                    Name = "Evil Rice Cooker",
                    MonsterType = MonsterTypeEnum.EvilRiceCooker,
                    Description = "This is a basic Monster",
                    ImageURI = "crock_pot.png",
                    SpecialDrop = SpecialDropEnum.Unknown,
                    MonsterClass = "Standard"
                },

                new MonsterModel {
                    Name = "Evil Crock pot",
                    MonsterType = MonsterTypeEnum.EvilCrockpot,
                    Description = "This is a basic Monster",
                    ImageURI = "crock_pot.png",
                    SpecialDrop = SpecialDropEnum.Unknown,
                    MonsterClass = "Standard"
                },

                new MonsterModel {
                    Name = "Evil Can Opener",
                    MonsterType = MonsterTypeEnum.EvilCanOpener,
                    Description = "This is a basic Monster",
                    ImageURI = "crock_pot.png",
                    SpecialDrop = SpecialDropEnum.Unknown,
                    MonsterClass = "Standard"
                },
            };

        return datalist;
    }
}
}