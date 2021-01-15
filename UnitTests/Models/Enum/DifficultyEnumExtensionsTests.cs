using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class DifficultyEnumExtensionsTests
    {
        [Test]
        public void DifficultyEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Unknown", result);
        }

        [Test]
        public void DifficultyEnumExtensionsTests_Easy_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnum.Easy.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Easy", result);
        }

        [Test]
        public void DifficultyEnumExtensionsTests_Average_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnum.Average.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Average", result);
        }

        [Test]
        public void DifficultyEnumExtensionsTests_Difficult_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnum.Difficult.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Harder than Hard", result);
        }

        [Test]
        public void DifficultyEnumExtensionsTests_Hard_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnum.Hard.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Hard", result);
        }

        [Test]
        public void DifficultyEnumExtensionsTests_Impossible_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnum.Impossible.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Impossible", result);
        }

        // Mike
        [Test]
        public void DifficultyEnumExtensionsTests_ToModifier_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnum.Unknown.ToModifier(10);

            // Reset

            // Assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public void DifficultyEnumExtensionsTests_ToModifier_Easy_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnum.Easy.ToModifier(10);

            // Reset

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void DifficultyEnumExtensionsTests_ToModifier_Average_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnum.Average.ToModifier(10);

            // Reset

            // Assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void DifficultyEnumExtensionsTests_ToModifier_Difficult_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnum.Difficult.ToModifier(10);

            // Reset

            // Assert
            Assert.AreEqual(15, result);
        }

        [Test]
        public void DifficultyEnumExtensionsTests_ToModifier_Hard_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnum.Hard.ToModifier(10);

            // Reset

            // Assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public void DifficultyEnumExtensionsTests_ToModifier_Impossible_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnum.Impossible.ToModifier(10);

            // Reset

            // Assert
            Assert.AreEqual(20, result);
        }
    }
}