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
            Assert.AreEqual(9, result.Count());
        }
    }
}