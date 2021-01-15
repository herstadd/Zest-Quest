using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class ItemLocationEnumExtensionsTests
    {
        [Test]
        public void ItemLocationEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Unknown", result);
        }

        [Test]
        public void ItemLocationEnumExtensionsTests_Head_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnum.PrimaryHand.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Primary Hand", result);
        }

        [Test]
        public void ItemLocationEnumExtensionsTests_Necklass_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnum.Necklass.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Necklass", result);
        }

        [Test]
        public void ItemLocationEnumExtensionsTests_PrimaryHand_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnum.PrimaryHand.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Primary Hand", result);
        }

        [Test]
        public void ItemLocationEnumExtensionsTests_OffHand_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnum.OffHand.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Off Hand", result);
        }

        [Test]
        public void ItemLocationEnumExtensionsTests_RightFinger_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnum.RightFinger.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Right Finger", result);
        }

        [Test]
        public void ItemLocationEnumExtensionsTests_LeftFinger_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnum.LeftFinger.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Left Finger", result);
        }

        [Test]
        public void ItemLocationEnumExtensionsTests_Finger_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnum.Finger.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Any Finger", result);
        }

        [Test]
        public void ItemLocationEnumExtensionsTests_Feet_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnum.Feet.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Feet", result);
        }
    }
}
