using NUnit.Framework;

using Game.Models;
using Game.Engine.EngineGame;

namespace UnitTests.Engine.EngineGame
{
    [TestFixture]
    public class BattleEngineGameTests
    {
        #region TestSetup
        BattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new BattleEngine();
            Engine.Round = new RoundEngine();
            Engine.Round.Turn = new TurnEngine();
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void BattleEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Constructor

    }
}