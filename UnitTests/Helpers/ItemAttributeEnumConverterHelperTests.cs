using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    class ItemAttributeEnumConverterHelperTests
    {
        [Test]
        public void ItemAttributeEnumConverterHelperTests_Convert__Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new ItemAttributeEnumConverter();

            var myObject = "CurrentHealth";
            var Expected = "Current Health";

            // Act
            var Result = myConverter.Convert(myObject, null, null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemAttributeEnumConverterHelperTests_Convert_Bool__Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new ItemAttributeEnumConverter();

            var myObject = true;
            var Expected = 0;

            // Act
            var Result = myConverter.Convert(myObject, null, null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemAttributeEnumConverterHelperTests_ConvertBack_Num__Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new ItemAttributeEnumConverter();
            var myObject = 10;
            var Expected = "Speed";

            // Act
            var Result = myConverter.ConvertBack(myObject, typeof(CharacterJobEnum), null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }
    }
}