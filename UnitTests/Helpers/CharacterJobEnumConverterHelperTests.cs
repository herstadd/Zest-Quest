using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    class CharacterJobEnumConverterHelperTests
    {
        [Test]
        public void CharacterJobEnumConverterHelperTests_Convert__Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new CharacterJobEnumConverter();

            var myObject = "HeadChef";
            var Expected = "Head Chef";

            // Act
            var Result = myConverter.Convert(myObject, null, null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void CharacterJobEnumConverterHelperTests_Num_Should_Pass()
        {
            // Arrange
            var myConverter = new CharacterJobEnumConverter();
            var myObject = 0;
            var Expected = 0;

            // Act
            var Result = myConverter.Convert(myObject, null, null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void CharacterJobEnumConverterHelperTests_ConvertBack__Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new CharacterJobEnumConverter();
            var myObject = "HeadChef";
            var Expected = CharacterJobEnum.HeadChef;

            // Act
            var Result = myConverter.ConvertBack(myObject, null, null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

    }
}