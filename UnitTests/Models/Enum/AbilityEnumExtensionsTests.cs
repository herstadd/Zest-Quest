using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class AbilityEnumExtensionsTests
    {
        [Test]
        public void AbilityEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("None", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Bandage_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Bandage.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Apply Bandages", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Barrier_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Barrier.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Barrier Defense", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Curse_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Curse.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Shout Curse", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Focus_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Focus.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Mental Focus", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Heal_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Heal.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Heal Self", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Nimble_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Nimble.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("React Quickly", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Quick_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Quick.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Anticipate", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Toughness_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Toughness.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Toughen Up", result);
        }
    }
}
