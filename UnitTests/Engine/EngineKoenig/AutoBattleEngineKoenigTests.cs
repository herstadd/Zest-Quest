using System.Threading.Tasks;
using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;
using Game.ViewModels;
using Game.Engine.EngineKoenig;

namespace UnitTests.Engine.EngineKoenig
{
    [TestFixture]
    public class AutoBattleEngineKoenigTests
    {
        #region TestSetup
        AutoBattleEngine AutoBattleEngine;

        [SetUp]
        public void Setup()
        {
            AutoBattleEngine = new AutoBattleEngine();

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


        [Test]
        public void AutoBattleEngine_Constructor_Valid_Battle_Round_Turn_Should_Pass()
        {
            // Arrange

            // Act
            var result = AutoBattleEngine;
            result.Battle = new BattleEngine();
            result.Battle.Round = new RoundEngine();
            result.Battle.Round.Turn = new TurnEngine();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

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
            CharacterIndexViewModel.Instance.ForceDataRefresh();

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
            CharacterIndexViewModel.Instance.ForceDataRefresh();

            //Assert
            Assert.AreEqual(true, result);
        }
        #endregion RunAutoBattle

        #region CreateCharacterParty
        [Test]
        public async Task AutoBattleEngine_CreateCharacterParty_Valid_Characters_Should_Assign_6()
        {
            //Arrange
            AutoBattleEngine.Battle.EngineSettings.MaxNumberPartyCharacters = 6;

            CharacterIndexViewModel.Instance.Dataset.Clear();

            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "1" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "2" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "3" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "4" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "5" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "6" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "7" });

            //Act
            var result = AutoBattleEngine.CreateCharacterParty();
            var count = AutoBattleEngine.Battle.EngineSettings.CharacterList.Count();
            var name = AutoBattleEngine.Battle.EngineSettings.CharacterList.ElementAt(5).Name;

            //Reset
            CharacterIndexViewModel.Instance.ForceDataRefresh();

            //Assert
            Assert.AreEqual(6, count);
            Assert.AreEqual("6", name);
        }

        [Test]
        public void AutoBattleEngine_CreateCharacterParty_Valid_Characters_CharacterIndex_None_Should_Create_6()
        {
            //Arrange
            AutoBattleEngine.Battle.EngineSettings.MaxNumberPartyCharacters = 6;

            CharacterIndexViewModel.Instance.Dataset.Clear();

            //Act
            var result = AutoBattleEngine.CreateCharacterParty();
            var count = AutoBattleEngine.Battle.EngineSettings.CharacterList.Count();

            //Reset
            CharacterIndexViewModel.Instance.ForceDataRefresh();

            //Assert
            Assert.AreEqual(6, count);
        }
        #endregion CreateCharacterParty   
    }
}