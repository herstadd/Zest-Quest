using System.Linq;

using NUnit.Framework;

using Game.Models;

namespace UnitTests.Helpers
{
    [TestFixture]
    class MonsterClassEnumHelperTests
    {
        [Test]
        public void MonsterClassEnumHelperHelper_GetListMonsterClass__Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterClassEnumHelper.GetListMonsterClass;

            // Reset

            // Assert
            Assert.AreEqual(2, result.Count());
        }
    }
}