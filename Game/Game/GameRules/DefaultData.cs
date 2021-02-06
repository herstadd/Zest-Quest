using System.Collections.Generic;

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
                    Name = "I1",
                    Description = "I1",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I2",
                    Description = "I2",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I3",
                    Description = "I3",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I4",
                    Description = "I4",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I5",
                    Description = "I5",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I6",
                    Description = "I6",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack
                },
            };

            for (int i = 0; i < 20; i++)
            {
                var item = new ItemModel
                {
                    ImageURI = "item.png",
                    Range = 2,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                };
                item.Name = "I" + (datalist.Count+1).ToString();
                item.Description = item.Name;

                datalist.Add(item);
            }

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
                    Name = "First Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "Second Score",
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
                    MaxHealth = 5,
                    ImageURI = "headchef.png",
                    Head = HeadString,
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
                    MaxHealth = 5,
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
                    MaxHealth = 5,
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
                    MaxHealth = 5,
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
                    MaxHealth = 5,
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
                    MaxHealth = 5,
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
                    Description = "Boss",
                    MonsterType = MonsterTypeEnum.EvilRefrigerator,
                    ImageURI = "item.png",
                    SpecialDrop = SpecialDropEnum.Refrigerator,
                },

                new MonsterModel {
                    Name = "Evil Toaster",
                    MonsterType = MonsterTypeEnum.EvilToaster,
                    Description = "Boss",
                    ImageURI = "item.png",
                    SpecialDrop = SpecialDropEnum.OnionRing,

                },

                new MonsterModel {
                    Name = "Evil Blender",
                    MonsterType = MonsterTypeEnum.EvilBlender,
                    Description = "Boss",
                    ImageURI = "item.png",
                    SpecialDrop = SpecialDropEnum.ButcherKnife,
                },

                new MonsterModel {
                    Name = "Evil Dishwasher",
                    MonsterType = MonsterTypeEnum.EvilDishwasher,
                    Description = "Standard",
                    ImageURI = "item.png",
                    SpecialDrop = SpecialDropEnum.Unknown,
                },

                new MonsterModel {
                    Name = "Evil Stove",
                    MonsterType = MonsterTypeEnum.EvilStove,
                    Description = "Standard",
                    ImageURI = "item.png",
                    SpecialDrop = SpecialDropEnum.Unknown,
                },

                new MonsterModel {
                    Name = "Evil Kitchen Sink",
                    MonsterType = MonsterTypeEnum.EvilKitchenSink,
                    Description = "Standard",
                    ImageURI = "item.png",
                    SpecialDrop = SpecialDropEnum.Unknown,

                },

                new MonsterModel {
                    Name = "Evil Rice Cooker",
                    MonsterType = MonsterTypeEnum.EvilRiceCooker,
                    Description = "Standard",
                    ImageURI = "item.png",
                    SpecialDrop = SpecialDropEnum.Unknown,
                },

                new MonsterModel {
                    Name = "Evil Crock pot",
                    MonsterType = MonsterTypeEnum.EvilCrockpot,
                    Description = "Standard",
                    ImageURI = "item.png",
                    SpecialDrop = SpecialDropEnum.Unknown,
                },

                new MonsterModel {
                    Name = "Evil Can Opener",
                    MonsterType = MonsterTypeEnum.EvilCanOpener,
                    Description = "Standard",
                    ImageURI = "item.png",
                    SpecialDrop = SpecialDropEnum.Unknown,
                },
            };

        return datalist;
    }
}
}