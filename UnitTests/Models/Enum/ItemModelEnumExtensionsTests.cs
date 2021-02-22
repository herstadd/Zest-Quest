using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class ItemModelEnumExtensionsTests
    {
        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_None_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.None.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("None", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_Apron_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.Apron.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Apron", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_Bandana_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.Bandana.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Bandana", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_ChefHat_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.ChefHat.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("ChefHat", result);
        }


    }
}
