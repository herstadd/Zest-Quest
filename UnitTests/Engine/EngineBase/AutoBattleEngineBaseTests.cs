using System.Threading.Tasks;
using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;
using Game.ViewModels;
using Game.Engine.EngineBase;

namespace UnitTests.Engine.EngineBase
{
    [TestFixture]
    public class AutoBattleEngineBaseTests
    {
        #region TestSetup
        AutoBattleEngineBase AutoBattleEngine;

        [SetUp]
        public void Setup()
        {
            AutoBattleEngine = new AutoBattleEngineBase();

            AutoBattleEngine.Battle = new BattleEngineBase();
            AutoBattleEngine.Battle.Round = new RoundEngineBase();
            AutoBattleEngine.Battle.Round.Turn = new TurnEngineBase();

            AutoBattleEngine.Battle.EngineSettings.CharacterList.Clear();
            AutoBattleEngine.Battle.EngineSettings.MonsterList.Clear();
            AutoBattleEngine.Battle.EngineSettings.CurrentDefender = null;
            AutoBattleEngine.Battle.EngineSettings.CurrentAttacker = null;

            AutoBattleEngine.Battle.StartBattle(true);   // Clear the Engine
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void AutoBattleEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AutoBattleEngine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }


        //[Test]
        //public void AutoBattleEngine_Constructor_Valid_Battle_Round_Turn_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    var result = AutoBattleEngine;
        //    result.Battle = new BattleEngineBase();
        //    result.Battle.Round = new RoundEngineBase();
        //    result.Battle.Round.Turn = new TurnEngineBase();

        //    // Reset

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        #endregion Constructor

        #region RunAutoBattle
        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Valid_Default_Should_Pass()
        {
            //Arrange

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(3);

            var data = new CharacterModel { Level = 1, MaxHealth = 10 };

            AutoBattleEngine.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            AutoBattleEngine.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            AutoBattleEngine.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            AutoBattleEngine.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            AutoBattleEngine.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            AutoBattleEngine.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));

            //Act
            var result = await AutoBattleEngine.RunAutoBattle();

            //Reset
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Valid_Monsters_1_Should_Pass()
        {
            //Arrange

            // Need to set the Monster count to 1, so the battle goes to Next Round Faster
            AutoBattleEngine.Battle.EngineSettings.MaxNumberPartyMonsters = 1;
            AutoBattleEngine.Battle.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            AutoBattleEngine.Battle.EngineSettings.CharacterList.Add(CharacterPlayerMike);

            //Act
            var result = await AutoBattleEngine.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_InValid_DetectInfinateLoop_Should_Return_False()
        {
            //Arrange

            // Trigger DetectInfinateLoop Loop
            var oldRoundCountMax = AutoBattleEngine.Battle.EngineSettings.MaxRoundCount;
            AutoBattleEngine.Battle.EngineSettings.MaxRoundCount = -1;

            //Act
            var result = await AutoBattleEngine.RunAutoBattle();

            //Reset
            AutoBattleEngine.Battle.EngineSettings.MaxRoundCount = oldRoundCountMax;

            //Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Valid_NewRound_Should_Return_True()
        {
            //Arrange

            AutoBattleEngine.Battle.EngineSettings.MaxNumberPartyMonsters = 1;
            AutoBattleEngine.Battle.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100,
                                Attack = 100,
                                Defense = 100,
                                Level = 1,
                                CurrentHealth = 111,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            AutoBattleEngine.Battle.EngineSettings.CharacterList.Add(CharacterPlayerMike);

            var MonsterPlayerSue = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 1,
                    Attack = 1,
                    Defense = 1,
                    Level = 1,
                    CurrentHealth = 1,
                    ExperienceTotal = 1,
                    ExperienceRemaining = 1,
                    Name = "Sue",
                    ListOrder = 2,
                });

            AutoBattleEngine.Battle.EngineSettings.MonsterList.Add(MonsterPlayerSue);
            
            //Act
            var result = await AutoBattleEngine.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(false, result);
        }
        #endregion RunAutoBattle

        //#region CreateCharacterParty
        //[Test]
        //public async Task AutoBattleEngine_CreateCharacterParty_Valid_Characters_Should_Assign_6()
        //{
        //    //Arrange
        //    AutoBattleEngine.Battle.EngineSettings.MaxNumberPartyCharacters = 6;

        //    CharacterIndexViewModel.Instance.Dataset.Clear();

        //    await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "1" });
        //    await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "2" });
        //    await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "3" });
        //    await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "4" });
        //    await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "5" });
        //    await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "6" });
        //    await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "7" });

        //    //Act
        //    var result = AutoBattleEngine.CreateCharacterParty();

        //    //Reset

        //    //Assert
        //    Assert.AreEqual(6, AutoBattleEngine.Battle.EngineSettings.CharacterList.Count());
        //    Assert.AreEqual("6", AutoBattleEngine.Battle.EngineSettings.CharacterList.ElementAt(5).Name);
        //}

        //[Test]
        //public void AutoBattleEngine_CreateCharacterParty_Valid_Characters_CharacterIndex_None_Should_Create_6()
        //{
        //    //Arrange
        //    AutoBattleEngine.Battle.EngineSettings.MaxNumberPartyCharacters = 6;

        //    CharacterIndexViewModel.Instance.Dataset.Clear();

        //    //Act
        //    var result = AutoBattleEngine.CreateCharacterParty();

        //    //Reset

        //    //Assert
        //    Assert.AreEqual(6, AutoBattleEngine.Battle.EngineSettings.CharacterList.Count());
        //}
        //#endregion CreateCharacterParty   

        #region DetectInfinateLoop
        [Test]
        public void AutoBattleEngine_DetectInfinateLoop_InValid_RoundCount_More_Than_Max_Should_Return_True()
        {
            // Arrange
            AutoBattleEngine.Battle.EngineSettings.BattleScore.RoundCount = AutoBattleEngine.Battle.EngineSettings.MaxRoundCount + 1;

            // Act
            var result = AutoBattleEngine.DetectInfinateLoop();

            // Reset

            // Assert
            Assert.AreEqual(true,result);
        }

        [Test]
        public void AutoBattleEngine_DetectInfinateLoop_InValid_TurnCount_Count_More_Than_Max_Should_Return_True()
        {
            // Arrange
            AutoBattleEngine.Battle.EngineSettings.BattleScore.TurnCount = AutoBattleEngine.Battle.EngineSettings.MaxTurnCount + 1;

            // Act
            var result = AutoBattleEngine.DetectInfinateLoop();

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void AutoBattleEngine_DetectInfinateLoop_Valid_Counts_Less_Than_Max_Should_Return_false()
        {
            // Arrange
            AutoBattleEngine.Battle.EngineSettings.BattleScore.TurnCount = AutoBattleEngine.Battle.EngineSettings.MaxTurnCount -1;
            AutoBattleEngine.Battle.EngineSettings.BattleScore.RoundCount = AutoBattleEngine.Battle.EngineSettings.MaxRoundCount - 1;

            // Act
            var result = AutoBattleEngine.DetectInfinateLoop();

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion DetectInfinateLoop
    }
}