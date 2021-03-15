using System.Linq;

using NUnit.Framework;

using Game.Models;

namespace UnitTests.Helpers
{
    [TestFixture]
    class MonsterTypeEnumHelperTests
    {
        [Test]
        public void MonsterTypeEnumHelperTests_ConvertMessageToEnum_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterTypeEnumHelper.ConvertMessageToEnum("TEST");

            // Reset

            // Assert
            Assert.AreEqual(MonsterTypeEnum.Unknown, result);
        }

        [Test]
        public void MonsterTypeEnumHelperTests_GetListItems_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterTypeEnumHelper.GetListItems;

            // Reset

            // Assert
            Assert.AreEqual(9, result.Count);
        }
    }
}