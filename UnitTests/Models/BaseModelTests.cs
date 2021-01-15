using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class BaseModelTests
    {
        [Test]
        public void BaseModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BaseModel<ItemModel>();

            // Reset

            // Assert
            Assert.AreEqual("This is an Item", result.Name);
        }

        [Test]
        public void BaseModel_Set_Default_Should_Pass()
        {
            // Arrange
            var result = new BaseModel<ItemModel>();

            // Act
            result.Id = "bogus";
            result.ImageURI = "uri";

            // Reset

            // Assert
            Assert.AreEqual("bogus", result.Id);
            Assert.AreEqual("uri", result.ImageURI);
        }

        [Test]
        public void BaseModel_Update_Default_Should_Pass()
        {
            // Arrange
            var data = new BaseModel<ItemModel>();

            // Act
            var result = data.Update(null);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
