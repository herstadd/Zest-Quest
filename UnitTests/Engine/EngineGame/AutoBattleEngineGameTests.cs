using System;
using System.Threading.Tasks;
using System.Linq;

//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

using Game.Models;
using Game.Helpers;
using Game.ViewModels;
using Game.Engine.EngineGame;


namespace UnitTests.Engine.EngineGame
{
    [TestFixture]
    public class AutoBattleEngineGameTests
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

            AutoBattleEngine.Battle.Round = new RoundEngine();
            AutoBattleEngine.Battle.Round.Turn = new TurnEngine();

            //AutoBattleEngine.Battle.StartBattle(true);   // Clear the Engine
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
        #endregion Constructor

    }
}