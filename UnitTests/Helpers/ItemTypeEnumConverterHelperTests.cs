using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    class ItemTypeEnumConverterHelperTests
    {
        [Test]
        public void ItemTypeEnumConverterHelperTests_Convert_Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new ItemTypeEnumConverter();

            var myObject = "ButcherKnifeNecklace";
            var Expected = "Butcher Knife Necklace";

            // Act
            var Result = myConverter.Convert(myObject, null, null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }
    }
}