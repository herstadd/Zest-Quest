using System.Linq;

using NUnit.Framework;

using Game.Models;

namespace UnitTests.Helpers
{
    [TestFixture]
    class CharacterJobEnumHelperTests
    {
        [Test]
        public void CharacterJobEnumHelper_GetJobList_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnumHelper.GetJobList;

            // Assert
            Assert.AreEqual(2,result.Count());

            // Assert
        }
    }
}