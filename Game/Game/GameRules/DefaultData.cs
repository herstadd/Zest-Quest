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
                    Name = "Chef Hat",
                    Type = ItemModelEnum.ChefHat,
                    Description = "A basic toque blanche worn by chefs worldwide",
                    ImageURI = "chef_hat.png",
                    Range = 0,
                    Damage = 9,
                    Value = 4,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "Bandana",
                    Type = ItemModelEnum.Bandana,
                    Description = "The headgear of choice for more rebellious chefs",
                    ImageURI = "bandana.png",
                    Range = 0,
                    Damage = 5,
                    Value = 3,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Speed
                },
                new ItemModel {
                    Name = "Roasted Turkey Hat",
                    Type = ItemModelEnum.RoastedTurkeyHat,
                    Description = "It might smell delicious, but this is for wearing, not eating",
                    ImageURI = "roasted_turkey_hat.png",
                    Range = 0,
                    Damage = 1,
                    Value = 4,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.MaxHealth
                },
                new ItemModel {
                    Name = "Butcher Knife Necklace",
                    Type = ItemModelEnum.ButcherKnifeNecklace,
                    Description = "Perfect for chefs living life on the edge",
                    ImageURI = "butcher_knife_necklace.png",
                    Range = 0,
                    Damage = 5,
                    Value = 3,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "Timer",
                    Type = ItemModelEnum.Timer,
                    Description = "Crucial equipment that all chefs should have",
                    ImageURI = "timer.png",
                    Range = 0,
                    Damage = 0,
                    Value = 4,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.MaxHealth
                },
                new ItemModel {
                    Name = "Apron",
                    Type = ItemModelEnum.Apron,
                    Description = "Helps keep your clothing clean when the kitchen gets messy",
                    ImageURI = "apron.png",
                    Range = 0,
                    Damage = 0,
                    Value = 3,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Defense
                },
                new ItemModel {
                    Name = "Refrigerator",
                    Type = ItemModelEnum.Refrigerator,
                    Description = "Only the strongest of chefs can weild a refrigerator",
                    ImageURI = "refrigerator.png",
                    Range = 1,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "Pan",
                    Type = ItemModelEnum.Pan,
                    Description = "Good for frying up some eggs or whacking an appliance gone evil",
                    ImageURI = "pan.png",
                    Range = 1,
                    Damage = 6,
                    Value = 4,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Defense
                },
                new ItemModel {
                    Name = "Knife",
                    Type = ItemModelEnum.Knife,
                    Description = "Dice and slice. Just don't cut yourself!",
                    ImageURI = "knife.png",
                    Range = 0,
                    Damage = 4,
                    Value = 4,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Speed
                },
                new ItemModel {
                    Name = "Cutting Board",
                    Type = ItemModelEnum.CuttingBoard,
                    Description = "Multipurpose: Can be used to cut on or as a weapon!",
                    ImageURI = "cutting_board.png",
                    Range = 0,
                    Damage = 7,
                    Value = 5,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "Ring Pop",
                    Type = ItemModelEnum.RingPop,
                    Description = "A sweet treat that also gives some stats",
                    ImageURI = "ring_pop.png",
                    Range = 0,
                    Damage = 0,
                    Value = 2,
                    Location = ItemLocationEnum.LeftFinger,
                    Attribute = AttributeEnum.MaxHealth
                },
                new ItemModel {
                    Name = "Scream Ring",
                    Type = ItemModelEnum.ScreamRing,
                    Description = "Hopefully the monsters are scared of loud noises!",
                    ImageURI = "scream_ring.png",
                    Range = 0,
                    Damage = 0,
                    Value = 5,
                    Location = ItemLocationEnum.RightFinger,
                    Attribute = AttributeEnum.Speed
                },
                new ItemModel {
                    Name = "Onion Ring",
                    Type = ItemModelEnum.OnionRing,
                    Description = "Tasty, fashionable, and practical",
                    ImageURI = "onion_ring.png",
                    Range = 0,
                    Damage = 0,
                    Value = 4,
                    Location = ItemLocationEnum.RightFinger,
                    Attribute = AttributeEnum.MaxHealth
                },
                new ItemModel {
                    Name = "Flip Flop",
                    Type = ItemModelEnum.FlipFlop,
                    Description = "Why are you wearing open toed shoes while cooking?",
                    ImageURI = "flipflop.png",
                    Range = 0,
                    Damage = 0,
                    Value = 5,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "Crocs",
                    Type = ItemModelEnum.Crocs,
                    Description = "So comfortable!",
                    ImageURI = "crocs.png",
                    Range = 0,
                    Damage = 0,
                    Value = 2,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Defense
                },
                new ItemModel {
                    Name = "Wookie Boots",
                    Type = ItemModelEnum.WookieBoots,
                    Description = "If you find hair in your food, don't look at me",
                    ImageURI = "wookie_boots.png",
                    Range = 0,
                    Damage = 0,
                    Value = 3,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Speed
                },
                new ItemModel {
                    Name = "Santa Shoes",
                    Type = ItemModelEnum.SantaShoes,
                    Description = "What food would you like for Christmas this year?",
                    ImageURI = "santa_shoes.png",
                    Range = 0,
                    Damage = 0,
                    Value = 5,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.MaxHealth
                },
                new ItemModel {
                    Name = "Fried Chicken Necklace",
                    Type = ItemModelEnum.FriedChickenNecklace,
                    Description = "Delicious Fried Chicken is never more than a glance away!",
                    ImageURI = "fried_chicken_necklace.png",
                    Range = 0,
                    Damage = 0,
                    Value = 3,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Defense
                },
                new ItemModel {
                    Name = "Gingerbread",
                    Type = ItemModelEnum.Gingerbread,
                    Description = "Run, run, as fast as you can, you can't catch me, I'm the gingerbread man!",
                    ImageURI = "gingerbread.png",
                    Range = 0,
                    Damage = 0,
                    Value = 3,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Speed
                },
                new ItemModel {
                    Name = "Viking Hat",
                    Type = ItemModelEnum.VikingHat,
                    Description = "Fight like it's 1000AD!",
                    ImageURI = "viking_hat.png",
                    Range = 0,
                    Damage = 0,
                    Value = 2,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "Pot",
                    Type = ItemModelEnum.Pot,
                    Description = "Good for cooking soup or your opponent",
                    ImageURI = "pot.png",
                    Range = 1,
                    Damage = 4,
                    Value = 4,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "Puppet",
                    Type = ItemModelEnum.Puppet,
                    Description = "Tell your enemies to talk to the hand! ... er, puppet",
                    ImageURI = "puppet.png",
                    Range = 2,
                    Damage = 0,
                    Value = 5,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Defense
                },
                new ItemModel {
                    Name = "Meat Guitar",
                    Type = ItemModelEnum.MeatGuitar,
                    Description = "Quick, play a song using whatever you have on hand!",
                    ImageURI = "meat_guitar.png",
                    Range = 0,
                    Damage = 0,
                    Value = 3,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Speed
                },
                new ItemModel {
                    Name = "Witch Nail",
                    Type = ItemModelEnum.WitchNail,
                    Description = "Scare your enemies with this scary witch part",
                    ImageURI = "witch_nail.png",
                    Range = 0,
                    Damage = 0,
                    Value = 3,
                    Location = ItemLocationEnum.RightFinger,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "Wedding Ring",
                    Type = ItemModelEnum.WeddingRing,
                    Description = "Nothing brings power and shields you from trouble like being married",
                    ImageURI = "wedding_ring.png",
                    Range = 0,
                    Damage = 0,
                    Value = 2,
                    Location = ItemLocationEnum.LeftFinger,
                    Attribute = AttributeEnum.Defense
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
        string NoItem = null;

        var datalist = new List<CharacterModel>()
        {
            new CharacterModel {
                Name = "Head Chef",
                Description = "Each gadget grants this character double the normal stat modifier",
                Level = 10,
                Job = CharacterJobEnum.HeadChef,
                MaxHealth = DiceHelper.RollDice(10, 10),
                ImageURI = "headchef.png",
                Head = "Chef Hat",
                Necklass = "Timer",
                PrimaryHand = "Refrigerator",
                OffHand = "Cutting Board",
                Feet = "Santa Shoes",
                RightFinger = "Onion Ring",
                LeftFinger = "Ring Pop",
                NumLives = 1,
                IsBuffGranted = false,
                TurnNumber = 0,
        },

            new CharacterModel {
                Name = "Sous Chef ",
                Description = "Able to move through the walls from top to bottom and from left to right, vice versa",
                Level = 1,
                Job = CharacterJobEnum.SousChef,
                MaxHealth = DiceHelper.RollDice(1, 10),
                ImageURI = "souschef.png",
                Head = NoItem,
                Necklass = NoItem,
                PrimaryHand = NoItem,
                OffHand = NoItem,
                Feet = NoItem,
                RightFinger = NoItem,
                LeftFinger = NoItem,
                NumLives = 1,
                IsBuffGranted = false,
                TurnNumber = 0,
            },

            new CharacterModel {
                Name = "School Chef ",
                Description = "Provide a 20% attack buff to the rest of team if the school chef dies in a battle",
                Level = 5,
                Job = CharacterJobEnum.SchoolChef,
                MaxHealth = DiceHelper.RollDice(5, 10),
                ImageURI = "schoolchef.png",
                Head = NoItem,
                Necklass = NoItem,
                PrimaryHand = "Pan",
                OffHand = NoItem,
                Feet = NoItem,
                RightFinger = NoItem,
                LeftFinger = NoItem,
                NumLives = 1,
                IsBuffGranted = false,
                TurnNumber = 0,
            },

            new CharacterModel {
                Name = "Sushi Chef ",
                Description = "Has the ability to attack from anywhere on the map with any gadget ",
                Level = 1,
                Job = CharacterJobEnum.SushiChef,
                MaxHealth = DiceHelper.RollDice(1, 10),
                ImageURI = "sushichef.png",
                Head = NoItem,
                Necklass = NoItem,
                PrimaryHand = NoItem,
                OffHand = NoItem,
                Feet = NoItem,
                RightFinger = NoItem,
                LeftFinger = NoItem,
                NumLives = 1,
                IsBuffGranted = false,
                TurnNumber = 0,
            },

            new CharacterModel {
                Name = "Cat Chef ",
                Description = "Has 50% chance of revival but Max Health will be cut down to 50% of previous Max Health when it revives",
                Level = 1,
                Job = CharacterJobEnum.CatChef,
                MaxHealth = DiceHelper.RollDice(1, 10),
                ImageURI = "catchef.png",
                Head = NoItem,
                Necklass = NoItem,
                PrimaryHand = NoItem,
                OffHand = NoItem,
                Feet = "Wookie Boots",
                RightFinger = NoItem,
                LeftFinger = NoItem,
                NumLives = 9,
                IsBuffGranted = false,
                TurnNumber = 0,
            },

            new CharacterModel {
                Name = "Home Cook",
                Description = "After winning a battle their current health will be recovered by 10% of original max health up to max health",
                Level = 10,
                Job = CharacterJobEnum.HomeCook,
                MaxHealth = DiceHelper.RollDice(10, 10),
                ImageURI = "homechef.png",
                Head = NoItem,
                Necklass = NoItem,
                PrimaryHand = NoItem,
                OffHand = NoItem,
                Feet = NoItem,
                RightFinger = NoItem,
                LeftFinger = NoItem,
                NumLives = 1,
                IsBuffGranted = false,
                TurnNumber = 0,
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
                    Description = "This fridge is sick of storing expired fruits, vegetables, and sauces. Watch out for its teeth!",
                    ImageURI = "monster_refrigerator.png",
                    UniqueDrop = ItemModelEnum.Refrigerator,
                    MonsterClass = MonsterClassEnum.Boss
                },

                new MonsterModel {
                    Name = "Evil Toaster",
                    MonsterType = MonsterTypeEnum.EvilToaster,
                    Description = "Maybe if you cleaned out the crumbs every once in a while, this toaster wouldn't be so evil",
                    ImageURI = "monster_toaster.png",
                    UniqueDrop = ItemModelEnum.OnionRing,
                    MonsterClass = MonsterClassEnum.Boss
                },

                new MonsterModel {
                    Name = "Evil Blender",
                    MonsterType = MonsterTypeEnum.EvilBlender,
                    Description = "Someone made one too many kale smoothies in this blender",
                    ImageURI = "evil_blender.png",
                    UniqueDrop = ItemModelEnum.ButcherKnifeNecklace,
                    MonsterClass = MonsterClassEnum.Boss
                },

                new MonsterModel {
                    Name = "Evil Dishwasher",
                    MonsterType = MonsterTypeEnum.EvilDishwasher,
                    Description = "This dishwasher will not clean your dishes",
                    ImageURI = "evil_dishwasher.png",
                    UniqueDrop = ItemModelEnum.None,
                    MonsterClass = MonsterClassEnum.Standard
                },

                new MonsterModel {
                    Name = "Evil Stove",
                    MonsterType = MonsterTypeEnum.EvilStove,
                    Description = "One hot oil splash too many sent the stove to the dark side",
                    ImageURI = "evil_stove.png",
                    UniqueDrop = ItemModelEnum.None,
                    MonsterClass = MonsterClassEnum.Standard
                },

                new MonsterModel {
                    Name = "Evil Kitchen Sink",
                    MonsterType = MonsterTypeEnum.EvilKitchenSink,
                    Description = "Brings a whole new meaning to throwing the kitchen sink",
                    ImageURI = "evil_kitchen_sink.png",
                    UniqueDrop = ItemModelEnum.None,
                    MonsterClass = MonsterClassEnum.Standard

                },

                new MonsterModel {
                    Name = "Evil Rice Cooker",
                    MonsterType = MonsterTypeEnum.EvilRiceCooker,
                    Description = "Good for cooking rice, porridge, oatmeal and its enemies",
                    ImageURI = "evil_rice_cooker.png",
                    UniqueDrop = ItemModelEnum.None,
                    MonsterClass = MonsterClassEnum.Standard
                },

                new MonsterModel {
                    Name = "Evil Crock pot",
                    MonsterType = MonsterTypeEnum.EvilCrockpot,
                    Description = "Ready to slowly take revenge",
                    ImageURI = "evil_crock_pot.png",
                    UniqueDrop = ItemModelEnum.None,
                    MonsterClass = MonsterClassEnum.Standard
                },

                new MonsterModel {
                    Name = "Evil Can Opener",
                    MonsterType = MonsterTypeEnum.EvilCanOpener,
                    Description = "Kinda rusty...kinda evil",
                    ImageURI = "evil_can_opener.png",
                    UniqueDrop = ItemModelEnum.None,
                    MonsterClass = MonsterClassEnum.Standard
                },
            };

        return datalist;
    }
}
}