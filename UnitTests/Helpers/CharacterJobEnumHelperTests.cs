using System.Linq;

using NUnit.Framework;

using Game.Models;

namespace UnitTests.Helpers
{
    [TestFixture]
    class CharacterJobEnumHelperTests
    { 
        [Test]
        public void CharacterJobEnumHelper_GetListItem__Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnumHelper.GetListItem;

            // Reset

            // Assert
            Assert.AreEqual(10, result.Count());
        }

        [Test]
        public void CharacterJobEnumHelper_ConvertMessageToEnum__Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnumHelper.ConvertMessageToEnum("Test");

            // Reset

            // Assert
            Assert.AreEqual(CharacterJobEnum.Unknown, result);
        }
    }
}