using System.Linq;

using NUnit.Framework;

using Game.Models;

namespace UnitTests.Helpers
{
    [TestFixture]
    class MonsterClassEnumHelperTests
    {
        [Test]
        public void MonsterClassEnumHelperHelper_GetListMonsterClass_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterClassEnumHelper.GetListMonsterClass;

            // Reset

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void MonsterClassEnumHelperHelper_ConvertStringToEnum_Boss_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterClassEnumHelper.ConvertStringToEnum("Boss");

            // Reset

            // Assert
            Assert.AreEqual(MonsterClassEnum.Boss, result);
        }
    }
}