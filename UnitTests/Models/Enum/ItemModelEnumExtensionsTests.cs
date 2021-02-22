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


    }
}
