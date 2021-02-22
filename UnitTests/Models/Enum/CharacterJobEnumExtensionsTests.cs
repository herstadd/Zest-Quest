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
        public void CharacterJobEnumExtensionsTests_HeadChef_ToMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.HeadChef.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Head Chef", result);
        }
    }
}
