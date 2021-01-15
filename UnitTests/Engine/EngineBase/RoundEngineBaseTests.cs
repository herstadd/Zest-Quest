using System.Threading.Tasks;
using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.ViewModels;
using Game.Engine.EngineBase;

namespace UnitTests.Engine.EngineBase
{
    [TestFixture]
    public class RoundEngineBaseTests
    {
        #region TestSetup
        BattleEngineBase Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new BattleEngineBase();
            Engine.Round = new RoundEngineBase();
            Engine.Round.Turn = new TurnEngineBase();

            Engine.Round.ClearLists();

            //Start the Engine in AutoBattle Mode
            Engine.StartBattle(true);
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void RoundEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void RoundEngine_Valid_Turn_Set_Should_Pass()
        {
            // Arrange

            // Act
            var result = new RoundEngineBase();
            result.Turn = new TurnEngineBase();

            // Reset

            // Assert
            Assert.IsNotNull(result.Turn);
        }
        #endregion Constructor

        #region OrderPlayListByTurnOrder
        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Valid_Speed_Higher_Should_Be_Z()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceTotal = 1000,
                Name = "Z",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "C",
                ListOrder = 10
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EngineSettings.PlayerList = Engine.EngineSettings.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.Round.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual("Z", result[0].Name);
        }

        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Valid_Level_Higher_Should_Be_Z()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceTotal = 1000,
                Name = "Z",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "C",
                ListOrder = 10
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EngineSettings.PlayerList = Engine.EngineSettings.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.Round.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual("Z", result[0].Name);
        }

        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Valid_Experience_Higher_Should_Be_Z()
        {
            // Arrange

            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 100,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);

            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "C",
                ListOrder = 10,
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EngineSettings.PlayerList = Engine.EngineSettings.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.Round.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual("Z", result[0].Name);
        }

        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Valid_ListOrder_Should_Be_1()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "A",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "A",
                ListOrder = 10
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EngineSettings.PlayerList = Engine.EngineSettings.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.Round.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual(1, result[0].ListOrder);
        }

        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Valid_Name_A_Z_Should_Be_Z()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Both need to be character to fall through to the Name Test
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "ZZ",
                ListOrder = 10
            };

            CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EngineSettings.PlayerList = Engine.EngineSettings.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.Round.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual("Z", result[0].Name);
        }
        #endregion OrderPlayListByTurnOrder

        #region GetItemFromPoolIfBetter
        [Test]
        public async Task RoundEngine_GetItemFromPoolIfBetter_InValid_Location_Empty_Should_Fail()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Both need to be character to fall through to the Name Test
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
                Guid = "me"
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            var item1 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Location = ItemLocationEnum.Feet };
            var item2 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Location = ItemLocationEnum.Feet };

            await ItemIndexViewModel.Instance.CreateAsync(item1);
            await ItemIndexViewModel.Instance.CreateAsync(item2);

            Engine.EngineSettings.ItemPool.Add(item1);
            Engine.EngineSettings.ItemPool.Add(item2);

            // Put the Item on the Character
            Character.Head = null;

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act

            var result = Engine.Round.GetItemFromPoolIfBetter(CharacterPlayer, ItemLocationEnum.Feet);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(item2.Id, CharacterPlayer.Feet);    // The 2nd item is better, so did they swap?
        }

        [Test]
        public async Task RoundEngine_GetItemFromPoolIfBetter_Valid_PrimaryHand_Better_Should_Pass()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Both need to be character to fall through to the Name Test
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
                Guid = "me"
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            var item1 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Location = ItemLocationEnum.PrimaryHand };
            var item2 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Location = ItemLocationEnum.PrimaryHand };

            await ItemIndexViewModel.Instance.CreateAsync(item1);
            await ItemIndexViewModel.Instance.CreateAsync(item2);

            Engine.EngineSettings.ItemPool.Add(item1);
            Engine.EngineSettings.ItemPool.Add(item2);

            // Put the Item on the Character
            Character.AddItem(ItemLocationEnum.PrimaryHand, item1.Id);

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.GetItemFromPoolIfBetter(CharacterPlayer, ItemLocationEnum.PrimaryHand);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(item2.Id, CharacterPlayer.PrimaryHand);    // The 2nd item is better, so did they swap?
        }

        [Test]
        public async Task RoundEngine_GetItemFromPoolIfBetter_InValid_PrimaryHand_Worse_Should_Skip()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Both need to be character to fall through to the Name Test
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
                Guid = "me"
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            var item1 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Location = ItemLocationEnum.PrimaryHand };
            var item2 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Location = ItemLocationEnum.PrimaryHand };

            await ItemIndexViewModel.Instance.CreateAsync(item1);
            await ItemIndexViewModel.Instance.CreateAsync(item2);

            Engine.EngineSettings.ItemPool.Add(item1);
            Engine.EngineSettings.ItemPool.Add(item2);

            // Put the Item on the Character
            Character.AddItem(ItemLocationEnum.PrimaryHand, item2.Id);

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.GetItemFromPoolIfBetter(CharacterPlayer, ItemLocationEnum.PrimaryHand);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(item2.Id, CharacterPlayer.PrimaryHand);    // Kept the one
        }

        [Test]
        public async Task RoundEngine_GetItemFromPoolIfBetter_InValid_Pool_Empty_Should_Fail()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Both need to be character to fall through to the Name Test
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
                Guid = "me"
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            var item1 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Location = ItemLocationEnum.PrimaryHand };
            var item2 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Location = ItemLocationEnum.PrimaryHand };

            await ItemIndexViewModel.Instance.CreateAsync(item1);
            await ItemIndexViewModel.Instance.CreateAsync(item2);

            //Engine.EngineSettings.ItemPool.Add(item1);
            //Engine.EngineSettings.ItemPool.Add(item2);

            // Put the Item on the Character
            Character.AddItem(ItemLocationEnum.PrimaryHand, item2.Id);

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.GetItemFromPoolIfBetter(CharacterPlayer, ItemLocationEnum.PrimaryHand);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task RoundEngine_GetItemFromPoolIfBetter_InValid_Right_Finger_Empty_Should_Pass()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Both need to be character to fall through to the Name Test
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
                Guid = "me"
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            var item1 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Location = ItemLocationEnum.Finger };
            var item2 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Location = ItemLocationEnum.Finger };

            await ItemIndexViewModel.Instance.CreateAsync(item1);
            await ItemIndexViewModel.Instance.CreateAsync(item2);

            Engine.EngineSettings.ItemPool.Add(item1);
            Engine.EngineSettings.ItemPool.Add(item2);

            // Put the Item on the Character
            Character.AddItem(ItemLocationEnum.RightFinger, item1.Id);

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.GetItemFromPoolIfBetter(CharacterPlayer, ItemLocationEnum.RightFinger);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(item2.Id, CharacterPlayer.RightFinger);    // The 2nd item is better, so did they swap?
        }

        [Test]
        public async Task RoundEngine_GetItemFromPoolIfBetter_Valid_Left_Finger_Empty_Should_Pass()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Both need to be character to fall through to the Name Test
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
                Guid = "me"
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            var item1 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Location = ItemLocationEnum.Finger };
            var item2 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Location = ItemLocationEnum.Finger };

            await ItemIndexViewModel.Instance.CreateAsync(item1);
            await ItemIndexViewModel.Instance.CreateAsync(item2);

            Engine.EngineSettings.ItemPool.Add(item1);
            Engine.EngineSettings.ItemPool.Add(item2);

            // Put the Item on the Character
            Character.AddItem(ItemLocationEnum.LeftFinger, item1.Id);

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.GetItemFromPoolIfBetter(CharacterPlayer, ItemLocationEnum.LeftFinger);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(item2.Id, CharacterPlayer.LeftFinger);    // The 2nd item is better, so did they swap?
        }
        #endregion GetItemFromPoolIfBetter

        #region PickupItemsFromPool
        [Test]
        public void RoundEngine_PickupItemsFromPool_Valid_Default_Should_Pass()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Both need to be character to fall through to the Name Test
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
                Guid = "me"
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.PickupItemsFromPool(CharacterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion PickupItemsFromPool

        #region EndRound
        [Test]
        public void RoundEngine_EndRound_Valid_Default_Should_Pass()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Both need to be character to fall through to the Name Test
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
                Guid = "me"
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.EndRound();

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion EndRound

        #region RoundNextTurn
        [Test]
        public void RoundEngine_RoundNextTurn_Valid_No_Characters_Should_Return_GameOver()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Characer",
                ListOrder = 1,
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            Engine.EngineSettings.CharacterList.Clear();

            Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.RoundNextTurn();

            // Reset

            // Assert
            Assert.AreEqual(RoundEnum.GameOver, result);
        }

        [Test]
        public void RoundEngine_RoundNextTurn_Valid_No_Monsters_Should_Return_NewRound()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Characer",
                ListOrder = 1,
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            Engine.EngineSettings.CharacterList.Clear();

            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            //Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.RoundNextTurn();

            // Reset

            // Assert
            Assert.AreEqual(RoundEnum.NewRound, result);
        }

        [Test]
        public void RoundEngine_RoundNextTurn_Valid_Characters_Monsters_Should_Return_NewRound()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Characer",
                ListOrder = 1,
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            Engine.EngineSettings.CharacterList.Clear();

            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.RoundNextTurn();

            // Reset

            // Assert
            Assert.AreEqual(RoundEnum.NextTurn, result);
        }
        #endregion RoundNextTurn

        #region GetNextPlayerInList
        [Test]
        public void RoundEngine_GetNextPlayerInList_Valid_Mike_Should_Return_Doug()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Arrange
            var CharacterPlayerMike = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 200,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Mike",
                                            ListOrder = 1,
                                        });

            var CharacterPlayerDoug = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 20,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Doug",
                                            ListOrder = 2,
                                        });

            var CharacterPlayerSue = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 2,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Sue",
                                            ListOrder = 3,
                                        });

            var MonsterPlayer = new PlayerInfoModel(
                                    new MonsterModel
                                    {
                                        Speed = 1,
                                        Level = 1,
                                        CurrentHealth = 1,
                                        ExperienceTotal = 1,
                                        Name = "Monster",
                                        ListOrder = 4,
                                    });

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            Engine.EngineSettings.CharacterList.Clear();

            Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayerDoug);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayerSue);

            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Set Mike as the Player
            Engine.EngineSettings.CurrentAttacker = CharacterPlayerMike;

            // Act
            var result = Engine.Round.GetNextPlayerInList();

            // Reset


            // Assert
            Assert.AreEqual("Doug", result.Name);
        }

        [Test]
        public void RoundEngine_GetNextPlayerInList_Valid_Sue_Should_Return_Monster()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Arrange
            var CharacterPlayerMike = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 200,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Mike",
                                            ListOrder = 1,
                                        });

            var CharacterPlayerDoug = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 20,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Doug",
                                            ListOrder = 2,
                                        });

            var CharacterPlayerSue = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 2,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Sue",
                                            ListOrder = 3,
                                        });

            var MonsterPlayer = new PlayerInfoModel(
                                    new MonsterModel
                                    {
                                        Speed = 1,
                                        Level = 1,
                                        CurrentHealth = 1,
                                        ExperienceTotal = 1,
                                        Name = "Monster",
                                        ListOrder = 4,
                                    });

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            Engine.EngineSettings.CharacterList.Clear();

            Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayerDoug);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayerSue);

            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Set Sue as the Player
            Engine.EngineSettings.CurrentAttacker = CharacterPlayerSue;

            // Act
            var result = Engine.Round.GetNextPlayerInList();

            // Reset


            // Assert
            Assert.AreEqual("Monster", result.Name);
        }

        [Test]
        public void RoundEngine_GetNextPlayerInList_Valid_Monster_Should_Return_Mike()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Arrange
            var CharacterPlayerMike = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 200,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Mike",
                                            ListOrder = 1,
                                        });

            var CharacterPlayerDoug = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 20,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Doug",
                                            ListOrder = 2,
                                        });

            var CharacterPlayerSue = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 2,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Sue",
                                            ListOrder = 3,
                                        });

            var MonsterPlayer = new PlayerInfoModel(
                                    new MonsterModel
                                    {
                                        Speed = 1,
                                        Level = 1,
                                        CurrentHealth = 1,
                                        ExperienceTotal = 1,
                                        Name = "Monster",
                                        ListOrder = 4,
                                    });

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            Engine.EngineSettings.CharacterList.Clear();

            Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayerDoug);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayerSue);

            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.GetNextPlayerInList();

            // Reset


            // Assert
            Assert.AreEqual("Mike", result.Name);
        }

        [Test]
        public void RoundEngine_GetNextPlayerInList_InValid_EmptyList_Should_Return_Null()
        {
            // Arrange

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            var CharacterPlayerSue = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 2,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Sue",
                                            ListOrder = 3,
                                        });

            var MonsterPlayer = new PlayerInfoModel(
                                    new MonsterModel
                                    {
                                        Speed = 1,
                                        Level = 1,
                                        CurrentHealth = 1,
                                        ExperienceTotal = 1,
                                        Name = "Monster",
                                        ListOrder = 4,
                                    });

            Engine.EngineSettings.CharacterList.Clear();

            Engine.EngineSettings.CharacterList.Add(CharacterPlayerSue);

            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Clear the List to cause the error
            Engine.EngineSettings.PlayerList.Clear();

            // Arrange

            // Act
            var result = Engine.Round.GetNextPlayerInList();

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void RoundEngine_GetNextPlayerInList_Valid_LastInList_Should_Return_FirstInList()
        {
            // Arrange

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            var CharacterPlayerMike = new PlayerInfoModel(
                                       new CharacterModel
                                       {
                                           Speed = 200,
                                           Level = 1,
                                           CurrentHealth = 1,
                                           ExperienceTotal = 1,
                                           Name = "Mike",
                                           ListOrder = 1,
                                       });

            var CharacterPlayerDoug = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 20,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Doug",
                                            ListOrder = 2,
                                        });

            var CharacterPlayerSue = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 2,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Sue",
                                            ListOrder = 3,
                                        });

            var MonsterPlayer = new PlayerInfoModel(
                                    new MonsterModel
                                    {
                                        Speed = 1,
                                        Level = 1,
                                        CurrentHealth = 1,
                                        ExperienceTotal = 1,
                                        Name = "Monster",
                                        ListOrder = 4,
                                    });

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            Engine.EngineSettings.CharacterList.Clear();

            Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayerDoug);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayerSue);

            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Set the current player to the last one in the list
            Engine.EngineSettings.CurrentAttacker = Engine.EngineSettings.PlayerList.Last();

            // Act
            var result = Engine.Round.GetNextPlayerInList();

            // Reset

            // Assert
            Assert.AreEqual(Engine.EngineSettings.PlayerList.First().Guid, result.Guid);
        }
        #endregion GetNextPlayerInList

        #region PlayerList
        [Test]
        public void RoundEngine_PlayerList_Valid_Default_Should_Pass()
        {
            // Act
            var result = Engine.Round.PlayerList();

            // Reset

            // Assert
            Assert.AreEqual(2, result.Count);
        }
        #endregion PlayerList
    }
}