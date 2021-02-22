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

        [Test]
        public void CharacterJobEnumExtensionsTests_SousChef_ToMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.SousChef.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Sous Chef", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_SchoolChef_ToMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.SchoolChef.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("School Chef", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_SushiChef_ToMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.SushiChef.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Sushi Chef", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_CatChef_ToMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.CatChef.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Cat Chef", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_HomeCook_ToMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.HomeCook.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Home Cook", result);
        }
    }
}
