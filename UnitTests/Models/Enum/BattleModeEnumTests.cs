using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class BattleModeEnumExtensionsTests
    {
        [Test]
        public void BattleModeEnumExtensionsTests_MapFull_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnum.MapFull.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Map All Actions", result);
        }

        [Test]
        public void BattleModeEnumExtensionsTests_MapNext_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnum.MapNext.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Map Next Button", result);
        }

        [Test]
        public void BattleModeEnumExtensionsTests_MapAbility_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnum.MapAbility.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Map Abilities", result);
        }

        [Test]
        public void BattleModeEnumExtensionsTests_SimpleNext_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnum.SimpleNext.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Simple Next", result);
        }

        [Test]
        public void BattleModeEnumExtensionsTests_SimpleAbility_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnum.SimpleAbility.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Simple Abilities", result);
        }

        [Test]
        public void BattleModeEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Unknown", result);
        }
    }
}
