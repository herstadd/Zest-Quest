using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class HomeMenuItemModelTests
    {
        [Test]
        public void HomeMenuItemModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new HomeMenuItemModel();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void HomeMenuItemModel_Set_Default_Should_Pass()
        {
            // Arrange
            var result = new HomeMenuItemModel();

            // Act

            // Test all the Setters
            result.Id = MenuItemEnum.Village;
            result.Title = "bogus title";

            // Reset

            // Assert

            // The Get is tested by retrieving it here as well.
            Assert.AreEqual("bogus title", result.Title);
            Assert.AreEqual(MenuItemEnum.Village, result.Id);
        }
    }
}
