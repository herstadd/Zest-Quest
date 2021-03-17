using NUnit.Framework;

using Game.Models;

namespace UnitTests.Helpers
{
    [TestFixture]
    public class ItemModelEnumHelperTests
    {
        [Test]
        public void ItemModelEnumHelperTests_ConvertMessageToEnum_Should_Pass()
        {
            // Arrange
            var Expected = ItemModelEnum.Unknown;

            // Act
            var Actual = ItemModelEnumHelper.ConvertMessageToEnum("Test");
            

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }
    }
}