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

        [Test]
        public void ItemTypeEnumConverterHelperTests_Convert_Boolean_Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new ItemTypeEnumConverter();

            var myObject = true;
            var Expected = 0;

            // Act
            var Result = myConverter.Convert(myObject, null, null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemTypeEnumConverterHelperTests_ConvertBack_Num__Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new ItemTypeEnumConverter();
            var myObject = 90;
            var Expected = "Knife";

            // Act
            var Result = myConverter.ConvertBack(myObject, typeof(ItemModelEnum), null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemTypeEnumConverterHelperTests_ConvertBack_bool__Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new ItemTypeEnumConverter();
            var myObject = true;
            var Expected = 0;

            // Act
            var Result = myConverter.ConvertBack(myObject, typeof(ItemModelEnum), null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }
    }
}