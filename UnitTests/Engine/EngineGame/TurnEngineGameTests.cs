using System.Linq;
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

        #region DetermineActionChoiceTest

        [Test]
        public void TurnEngine_DetermineActionChoice_should_throw_NotImplementedException()
        {
            // Arrange

            // Act


            // Reset

            // Assert
            try
            {
                Engine.Round.Turn.DetermineActionChoice(new PlayerInfoModel());
                Assert.Fail();
            }
            catch (NotImplementedException ex)
            {
                Assert.IsTrue(true);
            }
        }
        #endregion DetermineActionChoiceTest

        #region MoveAsTurnTest

        [Test]
        public void TurnEngine_MoveAsTurn_Valid_PlayerInfoModel_Should_Pass()
        {
            // Arrange

            // Act
            var Result = Engine.Round.Turn.MoveAsTurn(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(true, Result);
        }

        [Test]
        public void TurnEngine_MoveAsTurn_Monster_PlayerTypeEnum_Should_Throw_NotImplementedException()
        {
            // Arrange
            PlayerInfoModel player = new PlayerInfoModel();
            player.PlayerType = PlayerTypeEnum.Monster;

            // Act


            // Reset

            // Assert
            try
            {
                Engine.Round.Turn.MoveAsTurn(player);
                Assert.Fail();
            }
            catch (NotImplementedException ex)
            {
                Assert.IsTrue(true);
            }
        }
        #endregion MoveAsTurnTest

        #region ChooseToUseAbilityTest

        [Test]
        public void TurnEngine_ChooseToUseAbility_Should_Throw_NotImplementedException()
        {
            // Arrange

            // Act


            // Reset

            // Assert
            try
            {
                Engine.Round.Turn.ChooseToUseAbility(new PlayerInfoModel());
                Assert.Fail();
            }
            catch (NotImplementedException ex)
            {
                Assert.IsTrue(true);
            }
        }
        #endregion ChooseToUseAbilityTest

        #region UseAbilityTest

        [Test]
        public void TurnEngine_UseAbility_Should_Throw_NotImplementedException()
        {
            // Arrange

            // Act


            // Reset

            // Assert
            try
            {
                Engine.Round.Turn.UseAbility(new PlayerInfoModel());
                Assert.Fail();
            }
            catch (NotImplementedException ex)
            {
                Assert.IsTrue(true);
            }
        }
        #endregion UseAbilityTest

        #region AttackTest

        [Test]
        public void TurnEngine_Attack_Should_Throw_NotImplementedException()
        {
            // Arrange

            // Act


            // Reset

            // Assert
            try
            {
                Engine.Round.Turn.Attack(new PlayerInfoModel());
                Assert.Fail();
            }
            catch (NotImplementedException ex)
            {
                Assert.IsTrue(true);
            }
        }
        #endregion AttackTest


        #region AttackChoiceTest

        [Test]
        public void TurnEngine_AttackChoice_Should_Throw_NotImplementedException()
        {
            // Arrange

            // Act


            // Reset

            // Assert
            try
            {
                Engine.Round.Turn.AttackChoice(new PlayerInfoModel());
                Assert.Fail();
            }
            catch (NotImplementedException ex)
            {
                Assert.IsTrue(true);
            }
        }
        #endregion AttackChoiceTest

        #region SelectCharacterToAttackTest

        [Test]
        public void TurnEngine_SelectCharacterToAttack_Should_Throw_NotImplementedException()
        {
            // Arrange

            // Act


            // Reset

            // Assert
            try
            {
                Engine.Round.Turn.SelectCharacterToAttack();
                Assert.Fail();
            }
            catch (NotImplementedException ex)
            {
                Assert.IsTrue(true);
            }
        }
        #endregion SelectCharacterToAttackTest

        #region SelectMonsterToAttackTest

        [Test]
        public void TurnEngine_SelectMonsterToAttack_Should_Throw_NotImplementedException()
        {
            // Arrange

            // Act


            // Reset

            // Assert
            try
            {
                Engine.Round.Turn.SelectMonsterToAttack();
                Assert.Fail();
            }
            catch (NotImplementedException ex)
            {
                Assert.IsTrue(true);
            }
        }
        #endregion SelectMonsterToAttackTest

        #region TurnAsAttackTest

        [Test]
        public void TurnEngine_TurnAsAttack_Should_Throw_NotImplementedException()
        {
            // Arrange

            // Act


            // Reset

            // Assert
            try
            {
                Engine.Round.Turn.TurnAsAttack(new PlayerInfoModel(), new PlayerInfoModel());
                Assert.Fail();
            }
            catch (NotImplementedException ex)
            {
                Assert.IsTrue(true);
            }
        }

        #endregion TurnAsAttackTest

        #region BattleSettingsOverrideTest

        [Test]
        public void TurnEngine_BattleSettingsOverride_Should_Throw_NotImplementedException()
        {
            // Arrange

            // Act


            // Reset

            // Assert
            try
            {
                Engine.Round.Turn.BattleSettingsOverride(new PlayerInfoModel());
                Assert.Fail();
            }
            catch (NotImplementedException ex)
            {
                Assert.IsTrue(true);
            }
        }
        #endregion BattleSettingsOverrideTest

    }


}