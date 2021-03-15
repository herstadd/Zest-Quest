using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    class ItemLocationEnumConverterHelperTests
    {
        [Test]
        public void ItemLocationEnumConverterHelperTests_Convert_Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new ItemLocationEnumConverter();

            var myObject = "PrimaryHand";
            var Expected = "Primary Hand";

            // Act
            var Result = myConverter.Convert(myObject, null, null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

    }
}