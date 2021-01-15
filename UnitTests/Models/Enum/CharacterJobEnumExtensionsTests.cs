using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class CharacterJobEnumExtensionsTests
    {
        [Test]
        public void CharacterJobEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Player", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Fighter_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Fighter.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Fighter", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Cleric_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Cleric.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Cleric", result);
        }
    }
}
