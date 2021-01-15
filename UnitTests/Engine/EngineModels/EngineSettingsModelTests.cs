using NUnit.Framework;

using Game.Models;
using Game.Engine.EngineModels;
using System.Collections.Generic;

namespace UnitTests.Engine.EngineModels
{
    [TestFixture]
    public class EngineSettingsModelTests
    {
        [Test]
        public void EngineSettingsModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = EngineSettingsModel.Instance;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void EngineSettingsModel_Set_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = EngineSettingsModel.Instance;

            result.BattleScore = new ScoreModel();
            result.BattleMessagesModel = new BattleMessagesModel();
            result.ItemPool = new List<ItemModel>();
            result.MonsterList = new List<PlayerInfoModel>();
            result.CharacterList = new List<PlayerInfoModel>();
            result.CurrentAttacker = new PlayerInfoModel();
            result.CurrentDefender = new PlayerInfoModel();
            result.CurrentMapLocation = new CordinatesModel();
            result.MoveMapLocation = new CordinatesModel();
            result.PlayerList = new List<PlayerInfoModel>();
            result.MapModel = new MapModel();
            result.BattleSettingsModel = new BattleSettingsModel();

            result.MaxNumberPartyCharacters = 6;
            result.MaxNumberPartyMonsters = 6;
            result.MaxRoundCount = 100;
            result.MaxTurnCount = 1000;

            result.CurrentAction = ActionEnum.Unknown;
            result.PreviousAction = ActionEnum.Unknown;
            result.CurrentActionAbility = AbilityEnum.Heal;
            result.RoundStateEnum = RoundEnum.Unknown;
            result.BattleStateEnum = BattleStateEnum.Unknown;

            // Reset

            // Assert
            Assert.IsNotNull(result.BattleScore);
            Assert.IsNotNull(result.BattleMessagesModel);
            Assert.IsNotNull(result.ItemPool);
            Assert.IsNotNull(result.MonsterList);
            Assert.IsNotNull(result.CharacterList);
            Assert.IsNotNull(result.CurrentAction);
            Assert.IsNotNull(result.CurrentDefender);
            Assert.IsNotNull(result.CurrentMapLocation);
            Assert.IsNotNull(result.MoveMapLocation);
            Assert.IsNotNull(result.PlayerList);
            Assert.IsNotNull(result.MapModel);
            Assert.IsNotNull(result.BattleSettingsModel);

            Assert.AreEqual(6, result.MaxNumberPartyCharacters);
            Assert.AreEqual(6, result.MaxNumberPartyMonsters);
            Assert.AreEqual(100, result.MaxRoundCount);
            Assert.AreEqual(1000, result.MaxTurnCount);

            Assert.AreEqual(ActionEnum.Unknown, result.CurrentAction);
            Assert.AreEqual(ActionEnum.Unknown, result.PreviousAction);
            Assert.AreEqual(AbilityEnum.Heal, result.CurrentActionAbility);
            Assert.AreEqual(RoundEnum.Unknown, result.RoundStateEnum);
            Assert.AreEqual(BattleStateEnum.Unknown, result.BattleStateEnum);

        }

    }
}