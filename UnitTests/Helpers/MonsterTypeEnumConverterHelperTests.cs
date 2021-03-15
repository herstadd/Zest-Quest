using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    class MonsterTypeEnumConverterHelperTests
    {
        [Test]
        public void MonsterTypeEnumConverterHelperTests_Convert_Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new MonsterTypeEnumConverter();

            var myObject = "EvilRefrigerator";
            var Expected = "Evil Refrigerator";

            // Act
            var Result = myConverter.Convert(myObject, null, null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void MonsterTypeEnumConverterHelperTests_Convert_Boolean_Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new MonsterTypeEnumConverter();

            var myObject = true;
            var Expected = 0;

            // Act
            var Result = myConverter.Convert(myObject, null, null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void MonsterTypeEnumConverterHelperTests_ConvertBack_Num__Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new MonsterTypeEnumConverter();
            var myObject = 12;
            var Expected = "Evil Toaster";

            // Act
            var Result = myConverter.ConvertBack(myObject, typeof(ItemModelEnum), null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

    }
}