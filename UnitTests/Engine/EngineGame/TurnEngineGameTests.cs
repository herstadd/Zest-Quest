﻿using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;
using Game.ViewModels;
using Game.Engine.EngineGame;
using Game.Engine.EngineModels;
using System;

namespace UnitTests.Engine.EngineGame
{
    [TestFixture]
    public class TurnEngineGameTests
    {
        #region TestSetup
        BattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new BattleEngine();
            Engine.Round = new RoundEngine();
            Engine.Round.Turn = new TurnEngine();
            //Engine.StartBattle(true);   // Start engine in auto battle mode
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void TurnEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Constructor

        #region AttackTest

        [Test]
        public void TurnEngine_AttackTest_should_throw_NotImplementedException()
        {
            // Arrange

            // Act


            // Reset

            // Assert
            try
            {
                Engine.Round.Turn.TakeTurn(new PlayerInfoModel());
                Assert.Fail();
            }
            catch (NotImplementedException ex)   
            {
                Assert.IsTrue(true);
            }
        }
        #endregion AttackTest

    }
}